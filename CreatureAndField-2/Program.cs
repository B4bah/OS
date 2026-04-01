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
        public bool NextMove()
        {
            throw new NotImplementedException();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(10, 10);
            Point spawnPos = new Point(0, 9);
            Creature creature = new Creature(spawnPos, "TestCreature", field);

            Console.WriteLine("The start of the test: ");
            Console.WriteLine(creature.ToString() + "\n");
            while (true)
            {
                //Console.WriteLine(field.ToString());
                if (!creature.NextMove())
                {
                    break;
                }
                //Console.WriteLine(field.ToString());
                Console.WriteLine(creature.ToString());
                //break;
            }
            Console.WriteLine("The end of the test");
            Console.WriteLine(field.ToString());
            Console.ReadLine();
        }
    }
}
