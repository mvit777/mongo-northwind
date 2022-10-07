using Domain.Infrastructure.Interfaces;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;

namespace Domain.Infrastructure.repositories
{
    /// <summary>
    /// Never uses this class directly. 
    /// Use MongoRegionsService instead.
    /// </summary>
    public class RegionsRepository : BaseRepository<Regions>, IRegionsRepository
    {
        internal RegionsRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
