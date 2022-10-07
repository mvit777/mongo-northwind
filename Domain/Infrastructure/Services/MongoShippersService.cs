using Domain.Infrastructure.repositories;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;

namespace Domain.Infrastructure.services
{
    [Serializable]
    public class MongoShippersService : IMongoService
    {
        public MongoDBContext Context { get => _context; set => _context = value; }

        private MongoDBContext _context;

        private ShippersRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MongoShippersService(MongoDBContext context)
        {
            _context = context;
            _repo = new ShippersRepository(_context);
        }

        [JsonConstructor]
        public MongoShippersService(string context, string serviceName)
        {
            File.WriteAllText(@"c:\temp\context_as_string", context);
        }

        public async Task<Shippers> AddOrderAsync(Shippers order)
        {
            
            await _repo.Create(order);

            return await _repo.Get(order._id, true);
        }

        public async Task<List<Shippers>> Get()
        {
            return (List<Shippers>)await _repo.Get();
        }
        public async Task<Shippers> Get(string id)
        {
            return await _repo.Get(id, true);
        }
        public Shippers Update(Shippers obj)
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


