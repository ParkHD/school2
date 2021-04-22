using System;
using System.Collections.Generic;
using System.Text;
using Maze.Key;
namespace Maze.Key
{
    enum MAZE_KEY 
    {
        None   =  0,
        Player = '@',
        Blank  = ' ',
        Wall   = '#',
        Start  = 'S',
        End    = 'E',
    }
    enum DIS
    {
        Down,
        Left,
        Up,
        Right,
        Count,
    }

}
struct vector2
{
    public int x;
    public int y;
    public vector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return string.Format("{0},{1}", x, y);
    }
    public bool IsValid(int x, int y)
    {
        return (this.x == x) && (this.y == y);
    }
    public static vector2 operator +(vector2 a, vector2 b)
    {
        return new vector2(a.x + b.x, a.y + b.y);
    }
}
class MazeManager
{
    char[,] background;
    public vector2 startPos;
    public vector2 endPos;
    vector2 playerPos;
    
    public void InitBackGround(string[] stage)
    {
        background = new char[stage.Length, stage[0].Length];
        for (int i = 0; i < stage.Length; i++)
        {
            char[] array = stage[i].ToCharArray();
            for (int j = 0; j < array.Length; j++)
            {
                if(array[j] == (char)MAZE_KEY.Start)
                {
                    startPos = new vector2(i, j);
                    playerPos = new vector2(i, j);
                }
                if (array[j] == (char)MAZE_KEY.End)
                {
                    endPos = new vector2(i, j);
                }
                background[i, j] = array[j];
            }
        }
    }
    public void ShowBackGround()
    {
        Console.Clear();
        for (int i = 0; i < background.GetLength(0); i++)
        {
            for (int j = 0; j < background.GetLength(1); j++)
            {
                char word = background[i, j];
                if (playerPos.IsValid(i, j))
                    word = (char)MAZE_KEY.Player;

                Console.Write(word);
            }
            Console.WriteLine();
        }
    }
    public void SearchMaze(vector2 player, DIS count = 0)
    {
        MovePlayer(count);
    }
    private void MovePlayer(DIS vector = 0)
    {

    }
    private bool IsMove(vector2 origin, DIS vec)
    {
        switch(vec)
        {
            case DIS.Up:
                break;
            case DIS.Down:
                break;
            case DIS.Left:
                break;
            case DIS.Right:
                break;
        }
    }
}
