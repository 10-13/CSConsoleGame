using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Visualiztion.Dialog
{
    class ConsoleStringDialog
    {
        private readonly string StartValue;

        public string Value { get; set; }

        public ConsoleStringDialog(string value = "")
        {
            Value = value;
            StartValue = value;
        }

        public void Show(string CustomName = "Input string:")
        {
            ConsoleKeyInfo? key = null;
            while(key == null || key.Value.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\t\t" + CustomName);
                Console.WriteLine(Value.ToString());
                Console.WriteLine();
                Console.WriteLine("\tRESET [Esc]\tSET [Enter]");
                key = Console.ReadKey();
                    switch(key.Value.Key)
                    {
                        case ConsoleKey.Escape:
                            Value = StartValue;
                            break;
                        case ConsoleKey.Backspace:
                            if(Value.Length > 0)
                                Value = Value.Remove(Value.Length - 1);
                            break;
                        default:
                            Value += key.Value.KeyChar;
                            break;
                    }
            }
        }
    }
}
