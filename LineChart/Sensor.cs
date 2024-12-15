using System;

namespace LineChart
{
    internal class Sensor
    {
        double x;
        Random rnd = new Random();
        public double Measure()
        {
            x += 0.02;
            return Math.Sin(x) + (rnd.NextDouble() - 0.5);
        }
    }
}
