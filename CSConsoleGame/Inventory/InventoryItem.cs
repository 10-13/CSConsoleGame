using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Game.Inventory
{
	[Attributes.InventoryItemExtension]
	public class InventoryItem : ICloneable
	{
		[JsonProperty("name")]
		[Attributes.IngameViseble]
		public string ItemName { get; set; } = null;

		[JsonProperty("description")]
		[Attributes.IngameViseble]
		public string ItemDescription { get; set; } = null;

		[JsonProperty("type")]
		[Attributes.IngameViseble]
		public string ItemType { get; set; } = null;

		[JsonProperty("mass")]
		[Attributes.IngameViseble(Type = "physics")]
		public float? Mass { get; set; } = null;

		[JsonProperty("volume")]
		[Attributes.IngameViseble(Type = "physics")]
		public float? Volume { get; set; } = null;

		[JsonProperty("count")]
		[Attributes.IngameViseble(Type = "physics")]
		public int? Count { get; set; } = null;

		[JsonProperty("maxcount")]
		public int? MaxCount { get; set; } = null;

		public InventoryItem() { ItemType = this.GetType().Name; }

		public virtual object Clone()
		{
			return MemberwiseClone();
		}

        public override string ToString()
        {
			return ItemName;
        }
    }
}
