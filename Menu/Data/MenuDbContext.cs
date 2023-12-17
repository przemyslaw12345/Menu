using Menu.Classes_Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Menu.Data
{
	internal class MenuDbContext : DbContext
	{
		DbSet<Drink> Drinks => Set<Drink>();
		DbSet<Food> Food => Set<Food>();
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-GA3KCB6;Database=Menu_ZadanieDomowe;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
		}
	}
}
