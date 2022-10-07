using Domain.Infrastructure.repositories;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;

namespace Domain.Infrastructure.services
{
    [Serializable]
    public class MongoSuppliersService : IMongoService
    {
        public MongoDBContext Context { get => _context; set => _context = value; }

        private MongoDBContext _context;

        private SuppliersRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MongoSuppliersService(MongoDBContext context)
        {
            _context = context;
            _repo = new SuppliersRepository(_context);
        }

        [JsonConstructor]
        public MongoSuppliersService(string context, string serviceName)
        {
            File.WriteAllText(@"c:\temp\context_as_string", context);
        }

        public async Task<Suppliers> AddOrderAsync(Suppliers order)
        {
            
            await _repo.Create(order);

            return await _repo.Get(order._id, true);
        }

        public async Task<List<Suppliers>> Get()
        {
            return (List<Suppliers>)await _repo.Get();
        }
        public async Task<Suppliers> Get(string id)
        {
            return await _repo.Get(id, true);
        }
        public Suppliers Update(Suppliers obj)
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


