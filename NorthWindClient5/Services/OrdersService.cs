using Domain.Infrastructure.services;
using Domain.Models;
using static System.Net.WebRequestMethods;
using System.Net;
using System.Net.Http.Json;

namespace NorthWindClient5.Services
{
    public class OrdersService
    {
        private HttpClient _httpClient;
        private ConfigService _configService;
        private string _endpoint;

        public OrdersService(HttpClient httpClient, ConfigService cs){
            _httpClient = httpClient;
            _configService = cs;
        }
        public async Task<IEnumerable<Orders>> Orders()
        {
            var result = new List<Orders>();

            _endpoint = _configService.GetBaseUrl() + _configService.GetUrl("orders.endpoint");
            //endpointDetails = ConfigService.GetBaseUrl() + ConfigService.GetUrl("orderdetails.endpoint");
            result = await _httpClient.GetFromJsonAsync<List<Orders>>(_endpoint);

            return result;
        }
    }
}
