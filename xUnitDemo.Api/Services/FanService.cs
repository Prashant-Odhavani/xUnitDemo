using System.Net.Http;
using System.Text.Json;
using xUnitDemo.Api.Models;
using xUnitDemo.Api.Services.Interfaces;

namespace xUnitDemo.Api.Services;
public class FanService(IHttpClientFactory httpClientFactory) : IFanService
{
    public async Task<List<Fan>?> GetAllFans()
    {
        var client = httpClientFactory.CreateClient("jsonplaceholder");
        var response = await client.GetAsync("/fans");

        var data = response.Content.ReadAsStringAsync();
        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.Unauthorized:
                return null;
            case System.Net.HttpStatusCode.NotFound:
                return new List<Fan> { };
            default:
                return JsonSerializer.Deserialize<List<Fan>>(await response.Content.ReadAsStringAsync());
        }
    }
}
