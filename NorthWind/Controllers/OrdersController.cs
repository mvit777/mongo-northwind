using Domain.Infrastructure.services;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;
using NorthWind.Infrastructure;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly MongoOrdersService _mongoService;
        private MongoServiceInstanceRegister _register;
        private WsConfig _config;
        public OrdersController(ILogger<OrdersController> logger, MongoServiceInstanceRegister register, WsConfig config)
        {
            _logger = logger;
            _config = config;
            _register = register;
            _mongoService = (MongoOrdersService)_register?.GetServiceInstance("MongoOrdersService", _config?.GetMongoServiceIdentity("MongoOrdersService"));
        }
        // GET: api/<OrdersController>
        [HttpGet]
        [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
        public async Task<List<Orders>> GetAsync()
        {
            return await _mongoService.Get();
            
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<Orders> Get(string id)
        {
            return await _mongoService.Get(id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post(string value)
        {
            var Order = JsonConvert.DeserializeObject<Orders>(value);
            _mongoService.Update(Order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value)
        {
            var Order = JsonConvert.DeserializeObject<Orders>(value);
            _mongoService.Update(Order);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
