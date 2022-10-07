using Domain.Infrastructure.services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MV.Framework.interfaces;
using MV.Framework.providers;
using NorthWind.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly MongoCustomersService _mongoService;
        private MongoServiceInstanceRegister _register;
        private WsConfig _config;

        public CustomersController(ILogger<CustomersController> logger, MongoServiceInstanceRegister register, WsConfig config)
        {
            _logger = logger;
            _config = config;
            _register = register;
            _mongoService = (MongoCustomersService)_register?.GetServiceInstance("MongoCustomersService", _config?.GetMongoServiceIdentity("MongoCustomersService"));
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<List<Customers>> GetAsync()
        {
            return await _mongoService.Get();

        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
