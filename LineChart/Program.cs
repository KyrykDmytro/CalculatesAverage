using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LineChart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sensor = new Sensor();
            var averager = new Averager(sensor, 50);

            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            var raw = new Series();

            for (int i = 0; i < 1000; i++)
                raw.Points.Add(new DataPoint(i, averager.Measure()));

            raw.ChartType = SeriesChartType.FastLine;
            raw.Color = Color.Red;
            chart.Series.Add(raw);

            chart.Dock = DockStyle.Fill;
            var form = new Form();
            form.Controls.Add(chart);
            form.WindowState = FormWindowState.Maximized;
            Application.Run(form);
        }
    }
}
