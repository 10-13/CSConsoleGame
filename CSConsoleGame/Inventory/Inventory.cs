using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Game.Inventory
{
	[Attributes.InventoryItemExtension]
	public class Inventory
	{
		[JsonProperty("items")]
		public List<InventoryItem> Items { get; set; } = new List<InventoryItem>();

		public Inventory() { }
	}
}
