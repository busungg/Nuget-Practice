using Serilog;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Information("Log Start");
        }
    }
}
