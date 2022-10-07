using Domain.Infrastructure.repositories;
using Domain.Models;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;

namespace Domain.Infrastructure.services
{
    [Serializable]
    public class MongoProductsService : IMongoService
    {
        public MongoDBContext Context { get => _context; set => _context = value; }

        private MongoDBContext _context;

        private ProductsRepository _repo;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MongoProductsService(MongoDBContext context)
        {
            _context = context;
            _repo = new ProductsRepository(_context);
        }

        [JsonConstructor]
        public MongoProductsService(string context, string serviceName)
        {
            File.WriteAllText(@"c:\temp\context_as_string", context);
        }

        public async Task<Products> AddOrderAsync(Products order)
        {
            
            await _repo.Create(order);

            return await _repo.Get(order._id, true);
        }

        public async Task<List<Products>> Get()
        {
            return (List<Products>)await _repo.Get();
        }
        public async Task<Products> Get(string id)
        {
            return await _repo.Get(id, true);
        }
        public Products Update(Products obj)
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


