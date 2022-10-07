using Domain.Infrastructure.repositories;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;

namespace Domain.Infrastructure.services
{
    [Serializable]
    public class MongoEmployeesService : IMongoService
    {
        public MongoDBContext Context { get => _context; set => _context = value; }

        private MongoDBContext _context;

        private EmployeesRepository _orderRepo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MongoEmployeesService(MongoDBContext context)
        {
            _context = context;
            _orderRepo = new EmployeesRepository(_context);
        }

        [JsonConstructor]
        public MongoEmployeesService(string context, string serviceName)
        {
            File.WriteAllText(@"c:\temp\context_as_string", context);
        }

        public async Task<Employees> AddOrderAsync(Employees order)
        {
            
            await _orderRepo.Create(order);

            return await _orderRepo.Get(order._id, true);
        }

        public async Task<List<Employees>> Get()
        {
            return (List<Employees>)await _orderRepo.Get();
        }
        public async Task<Employees> Get(string id)
        {
            return await _orderRepo.Get(id, true);
        }
        public Employees Update(Employees obj)
        {
            _orderRepo.Update(obj);

            return obj;
        }
        public void Delete(string id)
        {
            _orderRepo.Delete(id, true);
        }
    }
}


