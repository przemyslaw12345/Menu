using Menu.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Repository
{
	internal interface IWriteRepository<in T>
		where T : class, IMenu
	{
		void Add(T item);	
		void RemoveItem(T item);
		void Edit();

		void Save();
	}
}
