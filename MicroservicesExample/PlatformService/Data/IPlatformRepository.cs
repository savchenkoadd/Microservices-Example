
using PlatformService.Models;

namespace PlatformService.Data
{
	public interface IPlatformRepository
	{
		Task<IEnumerable<Platform>?> GetAllPlatforms();

		Task<Platform?> GetById(Guid id);

		Task Create(Platform platform);
	}
}
