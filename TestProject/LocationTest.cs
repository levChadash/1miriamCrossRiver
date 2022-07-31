using CoronaApp.Dal;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Threading.Tasks;
using Xunit;

namespace CoronaApp.Tests;
public class LocationTest : IClassFixture<WebApplicationFactory<Program>>
{

    private WebApplicationFactory<Program> _coronaApp;
    public LocationTest(WebApplicationFactory<Program> coronaApp)
    {
        _coronaApp = coronaApp;
    }

    [Theory]
    [InlineData("api/Location/")]
    public async Task getLocationsByPatientId(string url)
    {
        //Arrange:
        var client = _coronaApp.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddScoped<IDalLocation,Mock>();
            });
        })
            .CreateClient();
        //Act:
        var res = await client.GetAsync(url);

        //Assert:
        res.EnsureSuccessStatusCode();
        Assert.NotEqual(res.Content, null);
    }

}

