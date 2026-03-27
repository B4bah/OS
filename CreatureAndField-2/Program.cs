using CreatureAndField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureAndField_2
{

    public class TestMoveStrategy : IMoveStrategy
    {
        public Point NextMove(Point currentPos, Field field)
        {
            throw new NotImplementedException();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(10, 10);
            Point spawnPos = new Point(0, 0);
            Creature creature = new Creature(spawnPos, "TestCreature", field);

            Console.WriteLine("The start of the test");
            while (true)
            {
                if (!creature.Move())
                {
                    break;
                }

                Console.WriteLine(creature.ToString());
            }
            Console.WriteLine("The end of the test");
            Console.ReadLine();
        }
    }
}
