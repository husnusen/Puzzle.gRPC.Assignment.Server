using Puzzle.gRPC.Assignment.Server.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Grpc.HealthCheck;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcHealthChecks().AddCheck("HealthCheck", () => HealthCheckResult.Healthy() );
builder.Services.AddScoped<IDataService, DataService>();  

var app = builder.Build();

// Configure the HTTP request pipeline. 
app.MapGrpcService<GetDataService>();
app.MapGrpcService<HealthChecksService>();
app.MapGrpcHealthChecksService();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
