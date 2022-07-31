using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProject;

public class Location:IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public Location(WebApplicationFactory<Program> factory)
    {
        _factory = factory;   
    }
    [Theory]
    [InlineData("/api/Location")]
    public async Task GetHttpReqest(string url)
    {
        //Arange
        var client=_factory.CreateClient();

        //Act
        var response=await client.GetAsync(url);
        //Assert
        response.EnsureSuccessStatusCode();

    }

}
