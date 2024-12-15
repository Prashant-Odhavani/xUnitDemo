using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using xUnitDemo.Api.Controllers;
using xUnitDemo.Api.Models;
using xUnitDemo.Api.Services.Interfaces;
using xUnitDemo.UnitTests.Fixtures;

namespace xUnitDemo.UnitTests.Systems.Controlles;

public class TestPostController
{
    private readonly Mock<IPostService> _postServiceMock;
    private readonly PostController _controller;

    public TestPostController()
    {
        _postServiceMock = new Mock<IPostService>();
        _controller = new PostController(_postServiceMock.Object);
    }

    [Fact]
    public async Task GetPosts_ShouldReturnOk_WithListOfPosts()
    {
        // Arrange
        _postServiceMock.Setup(service => service.GetPostsAsync())
            .ReturnsAsync(PostFixture.GetPosts());

        // Act
        var result = await _controller.GetPosts();

        // Assert
        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult.StatusCode.Should().Be(200);
        okResult.Value.Should().BeEquivalentTo(PostFixture.GetPosts());
    }

    [Fact]
    public async Task GetPostById_ShouldReturnNotFound_WhenPostDoesNotExist()
    {
        // Arrange
        _postServiceMock.Setup(service => service.GetPostByIdAsync(1))
            .ReturnsAsync((Post)null);

        // Act
        var result = await _controller.GetPostById(1);

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task GetComments_ShouldReturnOk_WithListOfComments()
    {
        // Arrange
        var comments = new List<Comment> { new Comment { Id = 1, PostId = 1, Body = "Test Comment" } };
        _postServiceMock.Setup(service => service.GetCommentsByPostIdAsync(1))
            .ReturnsAsync(comments);

        // Act
        var result = await _controller.GetComments(1);

        // Assert
        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult.StatusCode.Should().Be(200);
        okResult.Value.Should().BeEquivalentTo(comments);
    }

    [Fact]
    public async Task CreatePost_ShouldReturnCreated_WithPost()
    {
        // Arrange
        var post = new Post { Title = "New Post" };
        var createdPost = new Post { Id = 1, Title = "New Post" };
        _postServiceMock.Setup(service => service.CreatePostAsync(post))
            .ReturnsAsync(createdPost);

        // Act
        var result = await _controller.CreatePost(post);

        // Assert
        var createdResult = result as CreatedAtActionResult;
        createdResult.Should().NotBeNull();
        createdResult.StatusCode.Should().Be(201);
        createdResult.Value.Should().BeEquivalentTo(createdPost);
        createdResult.RouteValues["id"].Should().Be(createdPost.Id);
    }

    [Fact]
    public async Task UpdatePost_ShouldReturnNoContent()
    {
        // Arrange
        var post = new Post { Id = 1, Title = "Updated Post" };
        _postServiceMock.Setup(service => service.UpdatePostAsync(1, post))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.UpdatePost(1, post);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task DeletePost_ShouldReturnNoContent()
    {
        // Arrange
        _postServiceMock.Setup(service => service.DeletePostAsync(1))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeletePost(1);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }
}
