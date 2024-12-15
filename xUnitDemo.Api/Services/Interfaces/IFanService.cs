using xUnitDemo.Api.Models;

namespace xUnitDemo.Api.Services.Interfaces;

public interface IFanService
{
    Task<List<Fan>?> GetAllFans();
}
