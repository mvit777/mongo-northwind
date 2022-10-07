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
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly MongoEmployeesService _mongoService;
        private MongoServiceInstanceRegister _register;
        private WsConfig _config;

        public EmployeesController(ILogger<EmployeesController> logger, MongoServiceInstanceRegister register, WsConfig config)
        {
            _logger = logger;
            _config = config;
            _register = register;
            _mongoService = (MongoEmployeesService)_register?.GetServiceInstance("MongoEmployeesService", _config?.GetMongoServiceIdentity("MongoEmployeesService"));
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<List<Employees>> GetAsync()
        {
            return await _mongoService.Get();

        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
