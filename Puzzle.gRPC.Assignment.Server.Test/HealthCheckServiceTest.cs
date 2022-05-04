using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;
using Puzzle.gRPC.Assignment.Server.Protos;
using Puzzle.gRPC.Assignment.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbehave;

namespace Puzzle.gRPC.Assignment.Server.Test
{
    public class HealthCheckServiceTest
    {
        private readonly Mock<IHealthChckService> _healthCheckServiceMock;
        private readonly Mock<ILogger<HealthChecksService>> _loggerMock;
        private HealthChecksService _service;
        public HealthCheckServiceTest()
        {
            _healthCheckServiceMock = new Mock<IHealthChckService>();
            _loggerMock = new Mock<ILogger<HealthChecksService>>();

        }
        [Scenario]
        public void Check_Health_Successfully()
        {
            "Set up the call".x(() => {
                _healthCheckServiceMock.Setup(_ => _.CheckHealth()).ReturnsAsync(It.IsAny<HealthReport>());
                _service = new HealthChecksService(_loggerMock.Object, _healthCheckServiceMock.Object);

            });
            "Call service ".x(async () =>
            {
                await _service.CheckHealth(It.IsAny<Empty>(), It.IsAny<ServerCallContext>());
            });
            "Verify ".x(() =>
            {
                _healthCheckServiceMock.Verify(_ => _.CheckHealth(), Times.Once);
            });

        }
    }
}
