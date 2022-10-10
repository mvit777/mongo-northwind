using Domain.Infrastructure.services;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MV.Framework.providers;
using NorthWind.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly ILogger<ShippersController> _logger;
        private readonly MongoShippersService _mongoService;
        private MongoServiceInstanceRegister _register;
        private WsConfig _config;

        public ShippersController(ILogger<ShippersController> logger, MongoServiceInstanceRegister register, WsConfig config)
        {
            _logger = logger;
            _config = config;
            _register = register;
            _mongoService = (MongoShippersService)_register?.GetServiceInstance("MongoShippersService", _config?.GetMongoServiceIdentity("MongoShippersService"));
        }
        // GET: api/<ShippersController>
        [HttpGet]
        [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
        public async Task<List<Shippers>> GetAsync()
        {
            return await _mongoService.Get();

        }

        // GET api/<ShippersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShippersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShippersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShippersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
