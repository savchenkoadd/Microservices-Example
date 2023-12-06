using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
	public class PlatformRepository : IPlatformRepository
	{
		private readonly ApplicationDbContext _db;

		public PlatformRepository(
				ApplicationDbContext applicationDbContext
			)
		{
			_db = applicationDbContext;
		}

		public async Task Create(Platform platform)
		{
			await _db.Platforms.AddAsync(platform);
			await _db.SaveChangesAsync();
		}

		public async Task<IEnumerable<Platform>?> GetAllPlatforms()
		{
			return await _db.Platforms.ToListAsync();
		}

		public async Task<Platform?> GetById(Guid id)
		{
			return await _db.Platforms.FindAsync(id);
		}
	}
}
