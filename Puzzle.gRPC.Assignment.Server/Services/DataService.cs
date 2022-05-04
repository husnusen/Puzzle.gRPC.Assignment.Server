using Puzzle.gRPC.Assignment.Server.Protos;

namespace Puzzle.gRPC.Assignment.Server.Services
{
    public class DataService : IDataService
    {
        public Task<GetDataResponse> GetDataAsync(GetDataRequest req)
        {

            var columnValue = new[] { "value1", "value2", "value3" };
            var response = new GetDataResponse();
            response.Query = "";
            response.CurrentCount = 10;
            response.TotalCount = 20;
            response.Schema.AddRange(new[] { "Column1", "Column2", "Column3" });
            for (int i = 0; i < 20; i++)
            {
                var responseData = new Data();
                responseData.ColumnValue.Add(columnValue);
                response.Data.Add(responseData);
            }

            return Task.FromResult(response);
        }
    }
}
