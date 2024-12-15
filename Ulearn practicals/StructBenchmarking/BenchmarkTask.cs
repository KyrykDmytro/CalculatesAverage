using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace StructBenchmarking;
public class Benchmark : IBenchmark
{
    public double MeasureDurationInMs(ITask task, int repetitionCount)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        task.Run();
        var stopwatch = new Stopwatch();
        for (int i = 0; i < repetitionCount; i++)
        {
            stopwatch.Start();
            task.Run();
            stopwatch.Stop();
        }
        return stopwatch.Elapsed.TotalMilliseconds / repetitionCount;
    }
}

[TestFixture]
public class RealBenchmarkUsageSample
{
    [Test]
    public void StringConstructorFasterThanStringBuilder()
    {
        Benchmark benchmark = new Benchmark();
        TestStringBuilder testStringBuilder = new TestStringBuilder();
        TestStringConstructor testStringConstructor = new TestStringConstructor();
        int n = 1000;
        Assert.Less(benchmark.MeasureDurationInMs(testStringConstructor, n), benchmark.MeasureDurationInMs(testStringBuilder, n));
    }

    class TestStringBuilder : ITask
    {
        public void Run()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                stringBuilder.Append('a');
            }
            stringBuilder.ToString();
        }
    }

    class TestStringConstructor : ITask
    {
        public void Run()
        {
            new String('a', 1000);
        }
    }
}
