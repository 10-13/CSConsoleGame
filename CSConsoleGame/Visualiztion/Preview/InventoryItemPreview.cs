using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InventoryItem = Game.Inventory.InventoryItem;

namespace Game.Visualiztion.Preview
{
    public class InventoryItemPreview
    {
        private Menu.Menu menu;
        private List<string> data = new List<string>();
        private List<object> objs = new List<object>();
        private List<Tuple<string, string, object>> attributes = new List<Tuple<string, string, object>>();
        private readonly List<string> modes = new List<string>();
        private string selectedMode = "default";

        public InventoryItemPreview(InventoryItem item,Menu.Menu.MenuSettings settings = null)
        {
            attributes = (from h in item.GetType().GetProperties()
                          where h.GetCustomAttributes(true).FirstOrDefault(
                              new Func<object, bool>((object a) => 
                              { 
                                  return a is Inventory.Attributes.IngameVisebleAttribute;
                              })) != null 
                          select new Tuple<string, string, object>(h.Name, (h.GetCustomAttributes(true).FirstOrDefault(new Func<object, bool>((object a) => { return a is Inventory.Attributes.IngameVisebleAttribute; })) as Inventory.Attributes.IngameVisebleAttribute).Type, h.GetValue(item))).ToList();
            menu = new Menu.Menu(in data, settings);
            selectWuthMode();
            foreach (var k in attributes)
                if (!modes.Contains(k.Item2))
                    modes.Add(k.Item2);
        }

        private void selectWuthMode()
        {
            data.Clear();
            data.AddRange(from h in attributes where h.Item2 == selectedMode select h.Item1 + " = " + h.Item3.ToString());
            objs = (from h in attributes where h.Item2 == selectedMode select h.Item3).ToList();
        }

        public void Show()
        {
            ConsoleKeyInfo? key = null;
            while(key == null || key.Value.Key != ConsoleKey.Escape)
            {
                Console.Clear();
                menu.ToStream(Console.OpenStandardOutput());
                Console.WriteLine("\t DETAIL [Enter] \t LEFT [Esc] \t CHANGE MODE [f]");
                key = Console.ReadKey();
                switch (key.Value.Key)
                {
                    case ConsoleKey.Enter:
                        if(objs[menu.Position] is InventoryItem)
                        {
                            new InventoryItemPreview(objs[menu.Position] as InventoryItem).Show();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        menu.Position--;
                        break;
                    case ConsoleKey.DownArrow:
                        menu.Position++;
                        break;
                    case ConsoleKey.F:
                        var k = new Dialog.ConsoleSelectorDialog(modes);
                        k.Show();
                        selectedMode = k.Selected;
                        selectWuthMode();
                        break;
                }
            }
        }
    }
}
