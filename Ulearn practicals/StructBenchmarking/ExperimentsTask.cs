using System.Collections.Generic;
using System;

namespace StructBenchmarking;

public class Experiments
{
	public static ChartData BuildChartDataForArrayCreation(
		IBenchmark benchmark, int repetitionsCount)
	{
		var classesTimes = new List<ExperimentResult>();
		var structuresTimes = new List<ExperimentResult>();

		foreach(var i in Constants.FieldCounts)
		{
			var ClassArrayCreation = new ClassArrayCreationTask(i);
			var StructArrayCreation = new StructArrayCreationTask(i);

			double time = benchmark.MeasureDurationInMs(ClassArrayCreation, repetitionsCount);
			classesTimes.Add(new ExperimentResult(i, time));

			time = benchmark.MeasureDurationInMs(StructArrayCreation, repetitionsCount);
			structuresTimes.Add(new ExperimentResult(i, time));
			Console.WriteLine("i: {0}", i);
        }

        return new ChartData
		{
			Title = "Create array",
			ClassPoints = classesTimes,
			StructPoints = structuresTimes,
		};
	}

    public static ChartData BuildChartDataForMethodCall(
		IBenchmark benchmark, int repetitionsCount)
	{
		var classesTimes = new List<ExperimentResult>();
		var structuresTimes = new List<ExperimentResult>();

        foreach (var i in Constants.FieldCounts)
        {
            var callWithClass = new MethodCallWithClassArgumentTask(i);
            var callWithSruct = new MethodCallWithStructArgumentTask(i);

            double time = benchmark.MeasureDurationInMs(callWithClass, repetitionsCount);
            classesTimes.Add(new ExperimentResult(i, time));

            time = benchmark.MeasureDurationInMs(callWithSruct, repetitionsCount);
            structuresTimes.Add(new ExperimentResult(i, time));
        }

        return new ChartData
		{
			Title = "Call method with argument",
			ClassPoints = classesTimes,
			StructPoints = structuresTimes,
		};
	}
}