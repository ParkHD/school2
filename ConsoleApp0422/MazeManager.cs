using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Maze.Key;

namespace Maze.Key
{
    enum MAZE_KEY
    {
        None  = 0,
        Blank = ' ',  // 문자는 사실 숫자고 ASCII코드에 의해서 표현.
        Wall  = '#',
        Start = 'S',
        End   = 'E',
        Player = '@',
    }
    public enum VECTOR
    {
        // 플레이어가 움직이는 방향 순서.
        Down,
        Left,
        Up,
        Right,
        Count,
    }

}

public struct Vector2
{
    public int x;
    public int y;

    public Vector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool IsValid(int x, int y)
    {
        return (this.x == x) && (this.y == y);
    }
    public bool IsValid(Vector2 target)
    {
        return (this.x == target.x) && (this.y == target.y);
    }
    public override string ToString()
    {
        return string.Format("{0},{1}", x, y);
    }

    // 연산자 +정의
    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x + b.x, a.y + b.y);
    }
    public static bool operator ==(Vector2 a, Vector2 b) // ==는 세트로 !=도 만들어줘야함
    {
        return a.x == b.x && a.y == b.y;
    }
    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return a.x != b.x || a.y != b.y;
    }
}

class MazeManager
{
    // 백그라운드.
    char[,] background;

    Vector2 startPos;  // 시작 위치.
    Vector2 endPos;    // 도착 위치.
    Vector2 playerPos; // 나의 위치.

    Vector2 maxSize;

    Stack<Vector2> searchPath;
    // 스테이지 초기화.
    public void InitBackground(string[] stage)
    {
        // 백그라운드의 크기 지정.
        background = new char[stage.Length, stage[0].Length];
        maxSize = new Vector2(stage.Length, stage[0].Length);
        // 반복문.
        for (int i = 0; i < stage.Length; i++)
        {
            // 한줄... ######S##
            char[] array = stage[i].ToCharArray();

            for (int j = 0; j < array.Length; j++)
            {
                // char형 문자 하나.
                char word = array[j];

                // 만약 문자가 Start다.
                if(word == (char)MAZE_KEY.Start)
                {
                    startPos  = new Vector2(j, i);
                    playerPos = new Vector2(j, i);
                }
                else if(word == (char)MAZE_KEY.End)
                {
                    endPos = new Vector2(j, i);
                }

                background[i, j] = word;
            }
        }
        searchPath = new Stack<Vector2>();
        searchPath.Push(new Vector2(-1, -1));
    }
    public void ShowBackground()
    {
        Console.Clear();
        Console.WriteLine("출발지점:{0}, 도착지점:{1}", startPos.ToString(), endPos.ToString());
        Console.WriteLine("============================================");
        Console.WriteLine("플레이어 위치 : {0} ", playerPos.ToString());
        Console.WriteLine("============================================");
        ShowAllPath();
        for (int y = 0; y < background.GetLength(0); y++)
        {
            for (int x = 0; x < background.GetLength(1); x++)
            {
                char word = background[y, x];

                // 현재 출력 위치가 플레이어의 위치라면
                // 백그라운드가 아닌 플레이어의 문자를 그린다.
                if(playerPos.IsValid(x, y))
                    word = (char)MAZE_KEY.Player;

                Console.Write("{0} ", word);
                //Thread.Sleep(50);
            }

            Console.WriteLine();
        }
    }
    private void ShowAllPath()
    {
        Vector2[] array = searchPath.ToArray();
        for (int i = array.Length -1; i>0;i--)
        {
            Console.Write(array[i].ToString());
            Console.Write("->");
        }
        Console.WriteLine();
    }
    int searchCount = 0;
    public void SearchMaze()
    {
       for(VECTOR vec = 0;vec<VECTOR.Count;vec++)
        {
            ShowBackground();
            bool isValid = IsValidMove(playerPos, vec);

            Console.WriteLine("==================================================");
            Console.WriteLine("{0}방향으로 {1}", vec, isValid ? "이동 할 수 있습니다." : "이동할 수 없습니다.");
            Console.WriteLine("==================================================");
            Console.ReadLine();

            if (isValid)
            {
                searchPath.Push(playerPos);
                playerPos.AddVector(vec); 
                SearchMaze();
            }
        }
    }

    private void MovePlayer(VECTOR vector = 0)
    {
        
    }
    

    private bool IsValidMove(Vector2 origin, VECTOR vec)
    {
        origin.AddVector(vec);
        if (origin.x < 0 || origin.y < 0)
            return false;
        if (origin.x >= maxSize.x || origin.y >= maxSize.y)
            return false;

        if(origin.IsValid(searchPath.Peek()))
        {
            return false;
        }
        // 원점에서 vec방향을 움직였을 때. 그 곳이 유효한가?
        char word = background[origin.y, origin.x];

        // 해당 위치의 문자가 Blank일때.
        return (word == (char)MAZE_KEY.Wall);
    }
}
public static class MazeMethos   // 확장 메소소소드
{
    public static void AddVector(this ref Vector2 origin, VECTOR vec)
    {
        switch (vec)
        {
            case VECTOR.Up:
                origin += new Vector2(0, -1);
                break;
            case VECTOR.Down:
                origin += new Vector2(0, 1);
                break;
            case VECTOR.Left:
                origin += new Vector2(-1, 0);
                break;
            case VECTOR.Right:
                origin += new Vector2(1, 0);
                break;
        }
    }
}