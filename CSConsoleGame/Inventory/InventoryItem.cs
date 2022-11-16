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
		public string ItemName { get; set; } = null;

		[JsonProperty("description")]
		public string ItemDescription { get; set; } = null;

		[JsonProperty("type")]
		public string ItemType { get; set; } = null;

		[JsonProperty("mass")]
		public float? Mass { get; set; } = null;

		[JsonProperty("volume")]
		public float? Volume { get; set; } = null;

		[JsonProperty("count")]
		public int? Count { get; set; } = null;

		[JsonProperty("maxcount")]
		public int? MaxCount { get; set; } = null;

		public InventoryItem() { ItemType = this.GetType().Name; }

		public virtual object Clone()
		{
			return MemberwiseClone();
		}
	}
}
