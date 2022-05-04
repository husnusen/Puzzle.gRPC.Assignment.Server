using Puzzle.gRPC.Assignment.Server.Protos;

namespace Puzzle.gRPC.Assignment.Server.Services
{
    public interface IDataService
    {
        Task<GetDataResponse> GetDataAsync(GetDataRequest req);
    }
}
