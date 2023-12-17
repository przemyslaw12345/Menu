using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Classes_Interfaces
{
	public class cafeMenu : IMenu
	{
		public int Id { get; set; }
		public string itemName { get; set; } = null!;
		public float itemPrice { get; set; }
	}
}
