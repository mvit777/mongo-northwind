using Domain.Infrastructure.Interfaces;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;

namespace Domain.Infrastructure.repositories
{
    /// <summary>
    /// Never uses this class directly. 
    /// Use MongoProductsService instead.
    /// </summary>
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        internal ProductsRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
