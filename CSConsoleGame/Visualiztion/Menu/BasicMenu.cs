using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Visualiztion.Menu
{
    public interface IInputBinder 
    {
        event Action<ConsoleKey> OnInput;
    }
    
    public abstract class BasicMenu
    {
        public readonly ConsoleKey UpKey;
        public readonly ConsoleKey DownKey;
        public readonly ConsoleKey SelectKey;


        protected void OnInput(ConsoleKey key)
        {
            if (key == UpKey)
                Up();
            if (key == DownKey)
                Down();
            if (key == SelectKey)
                Select();
        }

        public BasicMenu(IInputBinder binder)
        {
            binder.OnInput += OnInput;
            UpKey = ConsoleKey.UpArrow;
            DownKey = ConsoleKey.DownArrow;
            SelectKey = ConsoleKey.Enter;
        }

        public BasicMenu(IInputBinder binder, ConsoleKey[] bindings)
        {
            binder.OnInput += OnInput;
            UpKey = bindings[0];
            DownKey = bindings[1];
            SelectKey = bindings[2];
        }

        public abstract void Up();
        public abstract void Down();
        public abstract void Select();
    }

    public class Menu<T> : BasicMenu
    {
        protected List<T> objectList = new List<T>();
        protected int SelectedObject = 0;

        public Menu(in List<T> objectList,IInputBinder binder) : base(binder)
        {
            this.objectList = objectList;

        }

        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Select()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            throw new NotImplementedException();
        }
    }

}
