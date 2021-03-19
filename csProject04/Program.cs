using System;
//using static csProject04.UnitData;
namespace csProject04
{
    using static UnitData;
    class Program
    {
        static Unit[] unitArray = new Unit[10];
        static void Main(string[] args)
        {
            Initunit();

            Unit unit1 = GetUnit(Unit.UnitKind.Marine, "마린1");
           
            Unit enemy1 = GetUnit(Unit.UnitKind.Ultra, "울트라1");
            Unit enemy2 = GetUnit(Unit.UnitKind.Ultra, "울트라2");

            enemy1.TakeDamage(unit1);

            enemy1.ShowInfo();
            enemy2.ShowInfo();

            enemy1.Heal(10);
            unit1.TakeDamage(enemy1);

            unit1.ShowInfo();
            enemy1.ShowInfo();
            enemy2.ShowInfo();
        }

        static void Initunit()
        {
            unitArray[0] = new Unit("Marine", 80, 0.2f, 2, Unit.UnitKind.Marine);
            unitArray[1] = new Unit("Ultra", 150, 0.3f, 15, Unit.UnitKind.Ultra);
            unitArray[2] = new Unit("Zergling", 50, 0.5f, 5, Unit.UnitKind.Zergling);
        }
        static Unit GetUnit(Unit.UnitKind unitKind, string name = "")
        {
            Unit unit = null;
            
            for(int i =0; i<unitArray.Length; i++)
            {
                if(unitArray[i] == null)
                    continue;
                if (unitArray[i].IsKind(unitKind))
                {
                    unit = new Unit(unitArray[i], name);
                    Console.WriteLine("{0}[{1}]가 생성되었습니다.", unit.Name, unitKind);
                    break;
                }
            }
            return unit;
        }
        //static Unit GetUnit(Unit.UnitKind unitKind, string name)
        //{
        //    return GetUnit(unitKind, "");
        //}
    }
}
