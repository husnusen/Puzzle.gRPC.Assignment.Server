using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;
using Puzzle.gRPC.Assignment.Server.Protos;
using Puzzle.gRPC.Assignment.Server.Services;
using Xbehave;
using Xunit;

namespace Puzzle.gRPC.Assignment.Server.Test
{
    public class GetDataServiceTest
    {
        private readonly Mock<IDataService> _dataServiceMock;
        private readonly Mock<ILogger<GetDataService>> _loggerMock;
        private GetDataService _service;
        public GetDataServiceTest()
        {
            _dataServiceMock = new Mock<IDataService>();
            _loggerMock = new Mock<ILogger<GetDataService>>();

        }
        [Scenario]
        public void Get_Data_Successfully()
        {
            "Set up the call".x(() => {
                _dataServiceMock.Setup(_ => _.GetDataAsync(It.IsAny<GetDataRequest>())).ReturnsAsync(It.IsAny<GetDataResponse>());
                _service = new GetDataService(_loggerMock.Object,_dataServiceMock.Object);

            });
            "Call service ".x(async () =>
            {
                await _service.GET_DATA(It.IsAny<GetDataRequest>(), It.IsAny<ServerCallContext>());
            });
            "Verify ".x(() =>
            {
                _dataServiceMock.Verify(_ => _.GetDataAsync(It.IsAny<GetDataRequest>()), Times.Once);
            });

        }
    }
}