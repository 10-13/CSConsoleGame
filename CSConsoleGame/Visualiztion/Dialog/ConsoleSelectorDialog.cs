using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Visualiztion.Dialog
{
    public class ConsoleSelectorDialog
    {
        private List<string> data;

		public string Selected { get; set; } = "";

        public ConsoleSelectorDialog(List<string> data)
        {
			this.data = data;
        }

        public void Show(string CustomName = "Input string:")
        {
			Menu.Menu menu = new Menu.Menu(data);
			menu.ToStream(Console.OpenStandardOutput());
			ConsoleKey key = ConsoleKey.A;
			while (key != ConsoleKey.Escape)
			{
				Console.Clear();
				Console.WriteLine(CustomName);
				menu.ToStream(Console.OpenStandardOutput());
				Console.WriteLine("\t\tSET [Enter]");
				key = Console.ReadKey().Key;
				if (key == ConsoleKey.UpArrow)
					menu.Position--;
				if (key == ConsoleKey.DownArrow)
					menu.Position++;
				if (key == ConsoleKey.Enter) 
				{
					Selected = data[menu.Position];
					return;
				}
			}
		}
    }
}
