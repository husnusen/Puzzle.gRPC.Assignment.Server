using Microsoft.Extensions.Diagnostics.HealthChecks;
using Puzzle.gRPC.Assignment.Server.Protos;
using HealthReport = Puzzle.gRPC.Assignment.Server.Protos.HealthReport;
using Puzzle.gRPC.Assignment.Server.Extensions;

namespace Puzzle.gRPC.Assignment.Server.Services
{
    public class HealthChckService : IHealthChckService
    {

        private readonly HealthCheckService _healthCheckService;
        public HealthChckService( HealthCheckService healthCheckService)
        { 
            _healthCheckService = healthCheckService;
        }
        public async  Task<HealthReport> CheckHealth()
        {
            var report = await _healthCheckService.CheckHealthAsync().ConfigureAwait(false);

            HealthReport healthReport = new HealthReport();
            healthReport.Entries.AddRange(report.Entries.Keys);
            healthReport.HealthStatus = report.Status.ToString();
            healthReport.TotalDuration = Google.Protobuf.WellKnownTypes.Duration.FromTimeSpan(report.TotalDuration);
            healthReport.TotalDurationInMilliSeconds = Google.Protobuf.WellKnownTypes.Duration.FromTimeSpan(report.TotalDuration).Nanos.ConvertToMilliSeconds();

            healthReport.ProcessId = Guid.NewGuid().ToString();

            return healthReport;
        }
    }
}
