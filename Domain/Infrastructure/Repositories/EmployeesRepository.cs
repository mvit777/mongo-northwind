using Domain.Infrastructure.Interfaces;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;

namespace Domain.Infrastructure.repositories
{
    /// <summary>
    /// Never uses this class directly. 
    /// Use MongoEmployeesService instead.
    /// </summary>
    public class EmployeesRepository : BaseRepository<Employees>, IEmployeesRepository
    {
        internal EmployeesRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
