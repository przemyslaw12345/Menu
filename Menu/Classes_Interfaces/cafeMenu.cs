using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Classes_Interfaces
{
	public class CafeMenu : IMenu
	{
		public int Id { get; set; }
		public string ItemName { get; set; } = null!;
		public float ItemPrice { get; set; }
	}
}
