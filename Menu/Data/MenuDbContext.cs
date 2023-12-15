using Menu.Classes_Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Menu.Data
{
	internal class MenuDbContext : DbContext
	{
		DbSet<Drinks> drinks => Set<Drinks>();
		DbSet<Food> food => Set<Food>();
		DbSet<rezMenu> menu => Set<rezMenu>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-GA3KCB6;Database=Menu_ZadanieDomowe;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
		}
	}
}
