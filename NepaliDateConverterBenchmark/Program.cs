using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using NepaliDateConverter;

[MemoryDiagnoser]
public class DateConverterServiceBenchmark
{
    private readonly IDateConverterService _service;
    private readonly string _testDateString;
    private readonly DateTime _testDateTime;

    public DateConverterServiceBenchmark()
    {
        _service = new DateConverterService();
        _testDateString = "2081/03/15";
        _testDateTime = DateTime.Now;
    }

    [Benchmark]
    public DateTime BenchmarkToAD()
    {
        return _service.ToAD(_testDateString);
    }

    [Benchmark]
    public NepaliDate BenchmarkToBS()
    {
        return _service.ToBS(_testDateTime);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<DateConverterServiceBenchmark>(ManualConfig.Create(DefaultConfig.Instance).WithOptions(ConfigOptions.DisableOptimizationsValidator));
        Console.ReadLine();
    }
}