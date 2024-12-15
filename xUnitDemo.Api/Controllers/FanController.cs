using Microsoft.AspNetCore.Mvc;
using xUnitDemo.Api.Services.Interfaces;

namespace xUnitDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FanController(IFanService fanService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var fans = await fanService.GetAllFans();

        if (fans.Count != 0)
        {
            return Ok(fans);
        }

        return NotFound();
    }
}
