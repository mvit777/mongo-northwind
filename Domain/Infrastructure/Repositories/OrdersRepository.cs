using Domain.Infrastructure.Interfaces;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;

namespace Domain.Infrastructure.repositories
{
    /// <summary>
    /// Never uses this class directly. I'm not (yet) making this class internal 
    /// for the sole purpose of testing.
    /// Use (Mongo)OrdersService instead.
    /// </summary>
    public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
    {
        internal OrdersRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}