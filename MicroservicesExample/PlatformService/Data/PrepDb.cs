using PlatformService.Models;

namespace PlatformService.Data
{
	public class PrepDb
	{
		public static async Task PrepPopulation(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				await SeedData(serviceScope.ServiceProvider.GetService<ApplicationDbContext>());
			}
		}

		private static async Task SeedData(ApplicationDbContext context)
		{
			if (!context.Platforms.Any())
			{
				Console.WriteLine("--> Seeding data");

				await context.Platforms.AddRangeAsync(
						new Platform()
						{
							Name = ".NET",
							Publisher = "Microsoft",
							Cost = "Free",
							Id = Guid.NewGuid()
						},
						new Platform()
						{
							Name = "SQL Server Express",
							Publisher = "Microsoft",
							Cost = "Free",
							Id = Guid.NewGuid()
						},
						new Platform()
						{
							Name = "Kubernetes",
							Publisher = "Cloud Native Computing Foundation",
							Cost = "Free",
							Id = Guid.NewGuid()
						}
					);

				await context.SaveChangesAsync();
			}
			else
			{
                Console.WriteLine("--> Already have data");
            }
		}
	}
}
