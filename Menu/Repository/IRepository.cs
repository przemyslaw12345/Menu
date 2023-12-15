using Menu.Classes_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Repository
{
	internal interface IRepository<T>:
		IReadRepository<T>,
		IWriteRepository<T>
		where T : class, IMenu
	{
	}
}
