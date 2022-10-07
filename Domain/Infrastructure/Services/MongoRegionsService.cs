using Domain.Infrastructure.repositories;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;

namespace Domain.Infrastructure.services
{
    [Serializable]
    public class MongoRegionsService : IMongoService
    {
        public MongoDBContext Context { get => _context; set => _context = value; }

        private MongoDBContext _context;

        private RegionsRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MongoRegionsService(MongoDBContext context)
        {
            _context = context;
            _repo = new RegionsRepository(_context);
        }

        [JsonConstructor]
        public MongoRegionsService(string context, string serviceName)
        {
            File.WriteAllText(@"c:\temp\context_as_string", context);
        }

        public async Task<Regions> AddOrderAsync(Regions order)
        {
            
            await _repo.Create(order);

            return await _repo.Get(order._id, true);
        }

        public async Task<List<Regions>> Get()
        {
            return (List<Regions>)await _repo.Get();
        }
        public async Task<Regions> Get(string id)
        {
            return await _repo.Get(id, true);
        }
        public Regions Update(Regions obj)
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


