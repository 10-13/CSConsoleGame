using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Game.Visualiztion.Menu
{
    public class Menu
    {
        private List<string> Items = new List<string>();

        private MenuSettings Settings = new MenuSettings();
        private int _pos = 0;
        public int Position
        {
            get
            {
                return _pos;
            }
            set
            {
                _pos = value;
                if (value >= Items.Count)
                    _pos = Items.Count - 1;
                if (value < 0)
                    _pos = 0;
            }
        }

        [Serializable]
        public class MenuSettings
        {
            [JsonProperty("width")]
            public int DrawFieldWidth { get; set; } = 20;

            [JsonProperty("height")]
            public int DrawFieldHeight { get; set; } = 10;

            public MenuSettings() { }
        }

        public Menu(in List<string> Items,MenuSettings settings = null)
        {
            Settings = settings == null ? new MenuSettings() : settings;
            this.Items = Items;
        }

        public override string ToString()
        {
            string Res = "\n";
            foreach (string str in Items)
                Res += "\t" + str + "\n\n";
            return Res;
        }
        
        public string[] GetAsLines()
        {
            string[] res = new string[Settings.DrawFieldHeight];
            int spos = Position - Settings.DrawFieldHeight / 4;
            for(int i = 0;i < Settings.DrawFieldHeight; i++)
            {
                if (i % 2 == 1 && i / 2 + spos < Items.Count && i / 2 + spos > -1)
                {
                    res[i] = "  " + (Position == spos + i / 2 ? ">" : " ") + " " + Items[spos + i / 2];
                    res[i] = res[i].Substring(0, Math.Min(Settings.DrawFieldWidth,res[i].Length));
                }
            }
            return res;
        }

        public void ToStream(Stream stream)
        {
            using(StreamWriter writer = new StreamWriter(stream))
            foreach(string str in GetAsLines())
            {
                    writer.WriteLine(str);
            }
        }
    }

}
