using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();

builder.WebHost.UseKestrel()
    .ConfigureKestrel(options =>
    {
        options.ListenAnyIP(8081, listenOptions => 
            { listenOptions.Protocols = HttpProtocols.Http2; });
        options.ListenAnyIP(8080, listenOptions => 
            { listenOptions.Protocols = HttpProtocols.Http1; });
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => { options.InjectStylesheet("/swagger-ui/SwaggerDark.css"); });

app.UseHttpsRedirection();
app.UseRouting();
//app.MapControllers();
app.UseAuthorization();

await app.RunAsync();