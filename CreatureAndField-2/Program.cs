using CreatureAndField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureAndField_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(10, 10);
            Point spawnPos = new Point(0, 9);
            Creature creature = new Creature(spawnPos, "TestCreature", field);

            Console.WriteLine(creature.ToString() + "\n");
            Console.WriteLine("The start of the test: ");
            while (true)
            {
                if (!creature.NextMove())
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
