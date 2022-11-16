using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Inventory
{
	public static class ItemExtension
	{
		public static InventoryItem GetStack(this InventoryItem item, int count, out int overbaundence)
		{
			InventoryItem res = item.Clone() as InventoryItem;
			int add = res.MaxCount.HasValue ? res.MaxCount.Value : count;
			overbaundence = (count > add) ? count - add : 0;
			add = Math.Min(add, count);
			res.Count = add;
			return res;
		}
	}
}
