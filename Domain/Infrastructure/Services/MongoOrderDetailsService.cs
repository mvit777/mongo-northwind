using Domain.Infrastructure.repositories;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;

namespace Domain.Infrastructure.services
{
    [Serializable]
    public class MongoOrderDetailsService : IMongoService
    {
        public MongoDBContext Context { get => _context; set => _context = value; }

        private MongoDBContext _context;

        private OrderDetailsRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MongoOrderDetailsService(MongoDBContext context)
        {
            _context = context;
            _repo = new OrderDetailsRepository(_context);
        }

        [JsonConstructor]
        public MongoOrderDetailsService(string context, string serviceName)
        {
            File.WriteAllText(@"c:\temp\context_as_string", context);
        }

        public async Task<OrderDetails> AddOrderDetailsAsync(OrderDetails item)
        {
            
            await _repo.Create(item);

            return await _repo.Get(item._id, true);
        }

        public async Task<List<OrderDetails>> Get()
        {
            return (List<OrderDetails>)await _repo.Get();
        }
        public async Task<OrderDetails> Get(string id)
        {
            return await _repo.Get(id, true);
        }
        public OrderDetails Update(OrderDetails obj)
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


