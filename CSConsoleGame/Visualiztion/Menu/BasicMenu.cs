using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Visualiztion.Menu
{
    public abstract class BasicMenu<T>
    {
        protected List<T> sourceList = new List<T>();

        public BasicMenu(in List<T> list)
        {
            sourceList = list;
        }

        public abstract void DrawToConsole();
    }
}
