using Domain.Infrastructure.repositories;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;

namespace Domain.Infrastructure.services
{
    [Serializable]
    public class MongoTerritoriesService : IMongoService
    {
        public MongoDBContext Context { get => _context; set => _context = value; }

        private MongoDBContext _context;

        private TerritoriesRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MongoTerritoriesService(MongoDBContext context)
        {
            _context = context;
            _repo = new TerritoriesRepository(_context);
        }

        [JsonConstructor]
        public MongoTerritoriesService(string context, string serviceName)
        {
            File.WriteAllText(@"c:\temp\context_as_string", context);
        }

        public async Task<Territories> AddOrderAsync(Territories order)
        {
            
            await _repo.Create(order);

            return await _repo.Get(order._id, true);
        }

        public async Task<List<Territories>> Get()
        {
            return (List<Territories>)await _repo.Get();
        }
        public async Task<Territories> Get(string id)
        {
            return await _repo.Get(id, true);
        }
        public Territories Update(Territories obj)
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


