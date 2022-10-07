using Domain.Infrastructure.repositories;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;

namespace Domain.Infrastructure.services
{
    [Serializable]
    public class MongoCustomersService : IMongoService
    {
        public MongoDBContext Context { get => _context; set => _context = value; }

        private MongoDBContext _context;

        private CustomersRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MongoCustomersService(MongoDBContext context)
        {
            _context = context;
            _repo = new CustomersRepository(_context);
        }

        [JsonConstructor]
        public MongoCustomersService(string context, string serviceName)
        {
            File.WriteAllText(@"c:\temp\context_as_string", context);
        }

        public async Task<Customers> AddOrderAsync(Customers order)
        {
            
            await _repo.Create(order);

            return await _repo.Get(order._id, true);
        }

        public async Task<List<Customers>> Get()
        {
            return (List<Customers>)await _repo.Get();
        }
        public async Task<Customers> Get(string id)
        {
            return await _repo.Get(id, true);
        }
        public Customers Update(Customers obj)
        {
            _repo.Update(obj);

            return obj;
        }
        public void Delete(string id)
        {
            _repo.Delete(id, true);
        }
    }
}


