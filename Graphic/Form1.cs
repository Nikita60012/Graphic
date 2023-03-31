using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update();

            trackBarA.Scroll += new EventHandler(trackBarA_Scroll);
            trackBarB.Scroll += new EventHandler(trackBarB_Scroll);
        }

        
        public void trackBarA_Scroll(object sender, EventArgs e)
        {
            update();
            chart.Invalidate();
        }
        public void trackBarB_Scroll(object sender, EventArgs e)
        {
            update();
            chart.Invalidate();
        }

        public void update()
        {
            double a = Convert.ToDouble(trackBarA.Value) / 2;
            double b = Convert.ToDouble(trackBarB.Value) / 2;

            Series series = new Series("y = asin(bx)");
            series.ChartType = SeriesChartType.Spline;
            series.BorderWidth = 3;

            for (double x = -10; x <= 10; x += 0.01)
            {
                double y = a * Math.Sin(b * x);
                series.Points.AddXY(x, y);
            }
            chart.Series.Clear();
            chart.Series.Add(series);
        }
    }
}
