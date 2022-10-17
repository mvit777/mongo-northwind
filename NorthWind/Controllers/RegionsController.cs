using Domain.Infrastructure.services;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MV.Framework.providers;
using Newtonsoft.Json;
using NorthWind.Infrastructure;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ILogger<RegionsController> _logger;
        private readonly MongoRegionsService _mongoService;
        private MongoServiceInstanceRegister _register;
        private WsConfig _config;

        public RegionsController(ILogger<RegionsController> logger, MongoServiceInstanceRegister register, WsConfig config)
        {
            _logger = logger;
            _config = config;
            _register = register;
            _mongoService = (MongoRegionsService)_register?.GetServiceInstance("MongoRegionsService", _config?.GetMongoServiceIdentity("MongoRegionsService"));
        }
        // GET: api/<RegionsController>
        [HttpGet]
        [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
        public async Task<List<Regions>> GetAsync()
        {
            return await _mongoService.Get();

        }
        // GET api/<RegionsController>/5
        [HttpGet("{id}")]
        public async Task<Regions> Get(string id)
        {
            return await _mongoService.Get(id);
        }
        // POST api/<RegionsController>
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            await Task.Run(() =>
            {
                var Order = JsonConvert.DeserializeObject<Regions>(value);
                try
                {
                    _mongoService.Update(Order);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);

                }
            });           
        }
        // PUT api/<RegionsController>
        [HttpPut]
        public async Task Put([FromBody] string value)
        {
            var Order = JsonConvert.DeserializeObject<Regions>(value);
            await _mongoService.AddOrderAsync(Order);
        }

        // DELETE api/<RegionsController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _mongoService.Delete(id);
        }
    }
}
