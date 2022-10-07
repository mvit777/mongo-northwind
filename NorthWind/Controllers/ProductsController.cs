using Domain.Infrastructure.services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MV.Framework.providers;
using NorthWind.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly MongoProductsService _mongoService;
        private MongoServiceInstanceRegister _register;
        private WsConfig _config;

        public ProductsController(ILogger<ProductsController> logger, MongoServiceInstanceRegister register, WsConfig config)
        {
            _logger = logger;
            _config = config;
            _register = register;
            _mongoService = (MongoProductsService)_register?.GetServiceInstance("MongoProductsService", _config?.GetMongoServiceIdentity("MongoProductsService"));
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<Products>> GetAsync()
        {
            return await _mongoService.Get();

        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
