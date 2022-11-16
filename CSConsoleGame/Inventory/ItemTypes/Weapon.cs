using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Game.Inventory.ItemTypes
{
	[Attributes.InventoryItemExtension]
	public class Weapon : InventoryItem
	{
		[JsonProperty("damage")]
		public int Damage { get; set; } = 0;

		[JsonProperty("ammo")]
		public Ammo AmmoPerShoot { get; set; } = null;

		public Weapon() { }

		public virtual object Clone()
		{
			return MemberwiseClone();
		}
	}
}
