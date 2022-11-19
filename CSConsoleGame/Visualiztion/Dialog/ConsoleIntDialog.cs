using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Visualiztion.Dialog
{
    public class ConsoleIntDialog
    {
        private readonly int StartValue;
        public int Value { get; set; }

        public ConsoleIntDialog(int value = 0)
        {
            Value = value;
            StartValue = value;
        }

        public void Show(string CustomName = "Input number:")
        {
            var key = ConsoleKey.A;
            while (key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\t\t" + CustomName);
                Console.WriteLine(Value.ToString());
                Console.WriteLine();
                Console.WriteLine("\tRESET [Esc]\tSET [Enter]");
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D0:
                        Value *= 10;
                        Value += 0;
                        break;
                    case ConsoleKey.D1:
                        Value *= 10;
                        Value += 1;
                        break;
                    case ConsoleKey.D2:
                        Value *= 10;
                        Value += 2;
                        break;
                    case ConsoleKey.D3:
                        Value *= 10;
                        Value += 3;
                        break;
                    case ConsoleKey.D4:
                        Value *= 10;
                        Value += 4;
                        break;
                    case ConsoleKey.D5:
                        Value *= 10;
                        Value += 5;
                        break;
                    case ConsoleKey.D6:
                        Value *= 10;
                        Value += 6;
                        break;
                    case ConsoleKey.D7:
                        Value *= 10;
                        Value += 7;
                        break;
                    case ConsoleKey.D8:
                        Value *= 10;
                        Value += 8;
                        break;
                    case ConsoleKey.D9:
                        Value *= 10;
                        Value += 9;
                        break;
                    case ConsoleKey.Escape:
                        Value = StartValue;
                        break;
                    case ConsoleKey.Delete:
                        Value /= 10;
                        break;
                }
            }
        }
    }
}
