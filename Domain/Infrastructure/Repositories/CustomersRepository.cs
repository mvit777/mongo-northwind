using Domain.Infrastructure.Interfaces;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;

namespace Domain.Infrastructure.repositories
{
    /// <summary>
    /// Never uses this class directly. 
    /// Use MongoCustomersService instead.
    /// </summary>
    public class CustomersRepository : BaseRepository<Customers>, ICustomersRepository
    {
        internal CustomersRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
