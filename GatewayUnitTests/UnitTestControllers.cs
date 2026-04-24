using Gateway.Controllers;

namespace GatewayUnitTests;

public class UnitTestControllers
{
    private readonly Controller _controller = new Controller();
     [Fact]
     public void TestHello()
     {
         var value = _controller.HelloWorld();
         
         Assert.Equal("Hello World", value);
     }
}