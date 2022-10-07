using Domain.Infrastructure.Interfaces;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;

namespace Domain.Infrastructure.repositories
{
    /// <summary>
    /// Never uses this class directly. 
    /// Use MongoShippersService instead.
    /// </summary>
    public class ShippersRepository : BaseRepository<Shippers>, IShippersRepository
    {
        internal ShippersRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
