using Domain.Infrastructure.repositories;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;
using System.Linq;

namespace Domain.Infrastructure.services
{
    [Serializable]
    public class MongoOrdersService : IMongoService
    {
        public MongoDBContext Context { get => _context; set => _context = value; }

        private MongoDBContext _context;

        private OrdersRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MongoOrdersService(MongoDBContext context)
        {
            _context = context;
            _repo = new OrdersRepository(_context);
        }

        [JsonConstructor]
        public MongoOrdersService(string context, string serviceName)
        {
            File.WriteAllText(@"c:\temp\context_as_string", context);
        }

        public async Task<Orders> AddOrderAsync(Orders order)
        {
            
            await _repo.Create(order);

            return await _repo.Get(order._id, true);
        }

        public async Task<List<Orders>> Get()
        {
            return (List<Orders>)await _repo.Get();
        }
        public async Task<Orders> Get(string id)
        {
            return await _repo.Get(id, true);
        }
        public Orders Update(Orders obj)
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

