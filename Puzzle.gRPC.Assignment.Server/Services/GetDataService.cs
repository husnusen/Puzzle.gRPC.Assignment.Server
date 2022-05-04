using Grpc.Core;
using Puzzle.gRPC.Assignment.Server.Protos;

namespace Puzzle.gRPC.Assignment.Server.Services
{
    public class GetDataService : GetData.GetDataBase
    {
        private readonly ILogger<GetDataService> _logger;
        private readonly IDataService _dataService;

        public GetDataService(ILogger<GetDataService> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }
        public override async Task<GetDataResponse> GET_DATA(GetDataRequest request, ServerCallContext context)
        {

            try
            {
                return await _dataService.GetDataAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex )
            {

                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
