using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Classes_Interfaces
{
	internal interface IMenu
	{
		int Id { get; set; }
		string itemName { get; set; }
		float itemPrice { get; set; }
	}
}
