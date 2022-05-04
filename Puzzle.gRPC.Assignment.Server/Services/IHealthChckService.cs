using Puzzle.gRPC.Assignment.Server.Protos;

namespace Puzzle.gRPC.Assignment.Server.Services
{
    public interface IHealthChckService
    {
        Task<HealthReport> CheckHealth();
    }
}
