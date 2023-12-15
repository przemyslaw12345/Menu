using Menu.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Repository
{
	internal interface IReadRepository<out T>
		where T : class, IMenu
	{
		public T GetSpecific(int id);
		public IEnumerable<T> GetAll();
	}
}
