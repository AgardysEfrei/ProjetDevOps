using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit.Abstractions;

namespace GatewayUnitTests;

public class IntegrationTestControllers(WebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task TestHello()
    {
        var response = await _client.GetAsync("/api/controller/hello");
        testOutputHelper.WriteLine(Convert.ToString(response));
        Assert.Equal("Hello World", await response.Content.ReadAsStringAsync());
    }
}