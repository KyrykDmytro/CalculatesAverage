using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Application = System.Windows.Forms.Application;

namespace ConsoleApp3
{
    internal class Program
    {
        static void BilldGraph(Func<double, double> func, Series series)
        {
            for (int i = 1; i < 10000; i += 10)
            {
                series.Points.Add(new DataPoint (i, func(i)));
            }
        }

        static void Main(string[] args)
        {
            var graph = new Series();

            Func<double, double> f = (x) =>  x;
            BilldGraph(f, graph);
            
            #region
            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            graph.ChartType = SeriesChartType.FastLine;
            graph.Color = Color.Green;
            graph.BorderWidth = 3;

            chart.Series.Add(graph);
            chart.Dock = DockStyle.Fill;
            var form = new Form();
            form.Controls.Add(chart);
            Application.Run(form);
            #endregion
        }
    }
}
