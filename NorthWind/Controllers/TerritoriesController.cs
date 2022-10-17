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
    public class TerritoriesController : ControllerBase
    {
        private readonly ILogger<TerritoriesController> _logger;
        private readonly MongoTerritoriesService _mongoService;
        private MongoServiceInstanceRegister _register;
        private WsConfig _config;

        public TerritoriesController(ILogger<TerritoriesController> logger, MongoServiceInstanceRegister register, WsConfig config)
        {
            _logger = logger;
            _config = config;
            _register = register;
            _mongoService = (MongoTerritoriesService)_register?.GetServiceInstance("MongoTerritoriesService", _config?.GetMongoServiceIdentity("MongoTerritoriesService"));
        }
        // GET: api/<TerritoriesController>
        [HttpGet]
        [EnableCors(PolicyName = "_myAllowSpecificOrigins")]
        public async Task<List<Territories>> GetAsync()
        {
            return await _mongoService.Get();

        }
        // GET api/<TerritoriesController>/5
        [HttpGet("{id}")]
        public async Task<Territories> Get(string id)
        {
            return await _mongoService.Get(id);
        }
        // POST api/<TerritoriesController>
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            await Task.Run(() =>
            {
                var Order = JsonConvert.DeserializeObject<Territories>(value);
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
        // PUT api/<TerritoriesController>
        [HttpPut]
        public async Task Put([FromBody] string value)
        {
            var Order = JsonConvert.DeserializeObject<Territories>(value);
            await _mongoService.AddOrderAsync(Order);
        }

        // DELETE api/<TerritoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _mongoService.Delete(id);
        }
    }
}
