using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Game.Inventory;
using Game.Inventory.ItemTypes;
using Game.Serialization;

using System.Dynamic;
using Newtonsoft.Json;

using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;

using ItemSerializeble = Game.Inventory.Attributes.InventoryItemExtensionAttribute;

namespace CSConsoleGame
{
	public static class Program
	{
		public static void Main()
		{
			Inventory myInventory = new Inventory();
			myInventory.Items.Add(new Weapon());
			{
				var item = myInventory.Items[0] as Weapon;

				item.Mass = 15;
				item.Count = 1;
				item.Volume = 2;
				item.ItemName = "AK - 47";
				item.ItemDescription = "Gun";
				item.MaxCount = 1;
				item.Damage = 10;
				item.AmmoPerShoot = new Ammo();
				item.AmmoPerShoot.Mass = 0;
				item.AmmoPerShoot.Volume = 0.000002f;
				item.AmmoPerShoot.Count = 1;
				item.AmmoPerShoot.ItemName = "7*62 Standart";
				item.AmmoPerShoot.ItemDescription = "Ammo";
				item.AmmoPerShoot.AmmoType = "7*62";
			}
			myInventory.Items.Add((myInventory.Items[0] as Weapon).AmmoPerShoot.Clone() as InventoryItem);
			{
				var item = myInventory.Items[1];

				item.Count = 1000;
			}

			var inf =  Console.ReadKey();
			

			Console.WriteLine(GSerializer.SerializeJSON(myInventory));
			Console.ReadLine();
		}
	}
}
