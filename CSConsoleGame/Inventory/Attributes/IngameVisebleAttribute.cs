using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Inventory.Attributes
{
    public class IngameVisebleAttribute : Attribute
    {
        public string Type { get; set; } = "default";
        public IngameVisebleAttribute() { }
    }
}
