namespace Puzzle.gRPC.Assignment.Server.Extensions
{
    public static class ConvertTimeUnits
    {
        public static long ConvertToMilliSeconds(this int nanos) => (long)(nanos * 0.000001);
    }
}
