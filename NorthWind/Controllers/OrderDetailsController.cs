using Domain.Infrastructure.services;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MV.Framework.interfaces;
using MV.Framework.providers;
using Newtonsoft.Json;
using NorthWind.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ILogger<OrderDetailsController> _logger;
        private readonly MongoOrderDetailsService _mongoService;
        private MongoServiceInstanceRegister _register;
        private WsConfig _config;
        public OrderDetailsController(ILogger<OrderDetailsController> logger, MongoServiceInstanceRegister register, WsConfig config)
        {
            _logger = logger;
            _config = config;
            _register = register;
            _mongoService = (MongoOrderDetailsService)_register?.GetServiceInstance("MongoOrderDetailsService", _config?.GetMongoServiceIdentity("MongoOrderDetailsService"));
        }
        // GET: api/<OrderDetailsController>
        [HttpGet]
        public async Task<List<OrderDetails>> GetAsync()
        {
            return await _mongoService.Get();

        }

        // GET api/<OrderDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderDetailsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderDetailsController>/5
        [HttpPut]
        public async Task Put([FromBody] string value)
        {
            var OrderDetail = JsonConvert.DeserializeObject<OrderDetails>(value);
            await _mongoService.AddOrderDetailsAsync(OrderDetail);
        }

        // DELETE api/<OrderDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _mongoService.Delete(id);
        }
    }
}
