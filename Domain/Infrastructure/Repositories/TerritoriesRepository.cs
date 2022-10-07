using Domain.Infrastructure.Interfaces;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;

namespace Domain.Infrastructure.repositories
{
    /// <summary>
    /// Never uses this class directly. 
    /// Use MongoTerritoriesService instead.
    /// </summary>
    public class TerritoriesRepository : BaseRepository<Territories>, ITerritoriesRepository
    {
        internal TerritoriesRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
