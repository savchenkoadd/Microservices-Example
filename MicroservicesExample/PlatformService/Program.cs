using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

namespace PlatformService
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMem"));
			builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();	
			builder.Services.AddControllers();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			await PrepDb.PrepPopulation(app);

			app.Run();
		}
	}
}