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
            [JsonIgnore]
            private int insertPos = 2;

            [JsonProperty("width")]
            public int DrawFieldWidth { get; set; } = 20;

            [JsonProperty("height")]
            public int DrawFieldHeight { get; set; } = 10;

            [JsonProperty("dewider")]
            public char DewiderSymbol { get; set; } = '-';

            [JsonProperty("selection")]
            public char SelectionSymbol { get; set; } = '>';

            [JsonProperty("rowspace")]
            public int RowSpace { get; set; } = 5;

            [JsonProperty("dewiderspace")]
            public int DewiderSpace { get; set; } = 2;

            [JsonProperty("selectposition")]
            public int SelectInnsertPosition
            {
                get
                {
                    return insertPos;
                }
                set
                {
                    insertPos = value > -1 ? Math.Min(RowSpace - 1, value) : 0;
                }
            }

            [JsonProperty("doubledewidercut")]
            public bool DoubleDewiderCut { get; set; } = true;

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
        
        private string GenerateSpace(int size,char symbol)
        {
            string res = "";
            for(int i = 0;i < size; i++)
                res += symbol;
            return res;
        }

        public string[] GetAsLines()
        {
            Position = Position;
            string[] res = new string[Settings.DrawFieldHeight];
            int spos = Position - Settings.DrawFieldHeight / 4;
            for(int i = 0;i < Settings.DrawFieldHeight; i++)
            {
                if (i % 2 == 1 && i / 2 + spos < Items.Count && i / 2 + spos > -1)
                {
                    
                    res[i] = GenerateSpace(Settings.RowSpace,' ') + Items[spos + i / 2];
                    if (Position == spos + i / 2)
                        res[i] = res[i].Insert(Settings.SelectInnsertPosition, Settings.SelectionSymbol.ToString());
                    if (res[i].Length > Settings.DrawFieldWidth)
                    {
                        res[i] = res[i].Substring(0, Settings.DrawFieldWidth - 3);
                        res[i] += "...";
                    }
                }
                else if(spos + i / 2 > -1 && spos + (i - 1) / 2 < Items.Count)
                {
                    res[i] = GenerateSpace(Settings.DewiderSpace, ' ') + GenerateSpace(Settings.DrawFieldWidth - Settings.DewiderSpace * (Settings.DoubleDewiderCut ? 2 : 1), Settings.DewiderSymbol) + (Settings.DoubleDewiderCut ? GenerateSpace(Settings.DewiderSpace, ' ') : "");
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
