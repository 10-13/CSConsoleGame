using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Game.Inventory.ItemTypes
{
	[Attributes.InventoryItemExtension]
	public class Ammo : InventoryItem
	{
		[JsonProperty("ammotype")]
		public string AmmoType { get; set; } = null;

		public Ammo() { }

		public override object Clone()
		{
			return MemberwiseClone();
		}
	}
}
