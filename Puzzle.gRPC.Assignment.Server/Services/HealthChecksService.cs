using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Puzzle.gRPC.Assignment.Server.Protos;
using HealthReport = Puzzle.gRPC.Assignment.Server.Protos.HealthReport;

namespace Puzzle.gRPC.Assignment.Server.Services
{
    public class HealthChecksService : HealthChecks.HealthChecksBase
    {
        private readonly ILogger<HealthChecksService> _logger;
        private readonly IHealthChckService _healthCheckService;

        public HealthChecksService(ILogger<HealthChecksService> logger, IHealthChckService healthCheckService)
        {
            _logger = logger;
            _healthCheckService = healthCheckService;
        } 
        public override async Task<HealthReport> CheckHealth(Empty request, ServerCallContext context)
        {

            try
            {
                return await _healthCheckService.CheckHealth().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError( ex,ex.Message);
                throw;
            }
        }
    }
}
