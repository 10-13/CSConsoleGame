using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Visualiztion.Menu
{
    public class InventoryMenu
    {
        private Menu menu;
        private List<string> actualNames = new List<string>();
        private Inventory.Inventory inventory = new Inventory.Inventory();

        public InventoryMenu(Inventory.Inventory inventory,Menu.MenuSettings settings = null)
        {
            menu = new Menu(actualNames, settings);
            actualNames = (from h in inventory.Items select h.ToString()).ToList();
        }

        public void ToStream(System.IO.Stream stream)
        {
            menu.ToStream(stream);
        }
    }
}
