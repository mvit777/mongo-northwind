using Domain.Infrastructure.Interfaces;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;

namespace Domain.Infrastructure.repositories
{
    /// <summary>
    /// Never uses this class directly. 
    /// Use MongoSuppliersService instead.
    /// </summary>
    public class SuppliersRepository : BaseRepository<Suppliers>, ISuppliersRepository
    {
        internal SuppliersRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
