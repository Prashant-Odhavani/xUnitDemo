using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using xUnitDemo.Api.Controllers;
using xUnitDemo.Api.Models;
using xUnitDemo.Api.Services.Interfaces;
using xUnitDemo.UnitTests.Fixtures;

namespace xUnitDemo.UnitTests.Systems.Controlles;
public class TestFanController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        // Arrange

        var mockFanService = new Mock<IFanService>();
        mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(FanFixture.GetFans());

        var fanController = new FanController(mockFanService.Object);

        //Act

        var result = (OkObjectResult) await fanController.Get();

        //Assert
        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Get_OnSuccess_InvokeService()
    {
        // Arrange

        var mockFanService = new Mock<IFanService>();
        mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(FanFixture.GetFans());

        var fanController = new FanController(mockFanService.Object);

        //Act

        var result = (OkObjectResult) await fanController.Get();

        //Assert
        mockFanService.Verify(service => service.GetAllFans(), Times.Once);

    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfFans()
    {
        // Arrange

        var mockFanService = new Mock<IFanService>();
        mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(FanFixture.GetFans());

        var fanController = new FanController(mockFanService.Object);

        //Act

        var result = (OkObjectResult)await fanController.Get();

        //Assert
        result.Should().BeOfType<OkObjectResult>();

        result.Value.Should().BeOfType<List<Fan>>();

    }

    [Fact]
    public async Task Get_OnSuccess_ReturnNotFound()
    {
        // Arrange

        var mockFanService = new Mock<IFanService>();
        mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync([]);

        var fanController = new FanController(mockFanService.Object);

        //Act

        var result = (NotFoundResult)await fanController.Get();

        //Assert
        result.Should().BeOfType<NotFoundResult>();

    }
}
