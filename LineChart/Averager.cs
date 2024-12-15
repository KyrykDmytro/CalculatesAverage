using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace LineChart
{
    class Averager
    {
        Sensor sensor;
        Queue<double> queue;
        int bufferLength;
        double sum;
        public Averager(Sensor sensor, int bufferLength)
        {
            this.sensor = sensor;
            this.bufferLength = bufferLength;
            queue = new Queue<double>();
        }
        public double Measure()
        {
            var value = sensor.Measure();
            queue.Enqueue(value);
            sum += value;
            if(queue.Count > bufferLength)
                sum -= queue.Dequeue();
            return sum / queue.Count;
        }
    }
}
