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
    public class SuppliersController : ControllerBase
    {
        private readonly ILogger<SuppliersController> _logger;
        private readonly MongoSuppliersService _mongoService;
        private MongoServiceInstanceRegister _register;
        private WsConfig _config;

        public SuppliersController(ILogger<SuppliersController> logger, MongoServiceInstanceRegister register, WsConfig config)
        {
            _logger = logger;
            _config = config;
            _register = register;
            _mongoService = (MongoSuppliersService)_register?.GetServiceInstance("MongoSuppliersService", _config?.GetMongoServiceIdentity("MongoSuppliersService"));
        }
        // GET: api/<SuppliersController>
        [HttpGet]
        [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
        public async Task<List<Suppliers>> GetAsync()
        {
            return await _mongoService.Get();

        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
