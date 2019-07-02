using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChartJSCore.Models;
using Microsoft.AspNetCore.Mvc;
using TesteChartJS.Models;

namespace TesteChartJS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Chart chart = new Chart();

            chart.Type = Enums.ChartType.Line;

            ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();
            data.Labels = new List<string>() { "January", "February", "March", "April", "May", "June", "July" };

            LineDataset dataset = new LineDataset()
            {
                Label = "My First dataset",
                Data = new List<double>() { 65, 59, 80, 81, 56, 55, 40 },
                Fill = "false",
                LineTension = 0.1,
                BackgroundColor = "rgba(75, 192, 192, 0.4)",
                BorderColor = "rgba(75,192,192,1)",
                BorderCapStyle = "butt",
                BorderDash = new List<int> { },
                BorderDashOffset = 0.0,
                BorderJoinStyle = "miter",
                PointBorderColor = new List<string>() { "rgba(75,192,192,1)" },
                PointBackgroundColor = new List<string>() { "#fff" },
                PointBorderWidth = new List<int> { 1 },
                PointHoverRadius = new List<int> { 5 },
                PointHoverBackgroundColor = new List<string>() { "rgba(75,192,192,1)" },
                PointHoverBorderColor = new List<string>() { "rgba(220,220,220,1)" },
                PointHoverBorderWidth = new List<int> { 2 },
                PointRadius = new List<int> { 1 },
                PointHitRadius = new List<int> { 10 },
                SpanGaps = false
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            ViewData["chart"] = chart;

            return View();
        }

        public IActionResult Scatter()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Line;

            Data data = new Data();

            var dataset1 = new LineScatterDataset() { Label = "Scatter Dataset", Data = new List<LineScatterData>(), BackgroundColor = "rgba(75, 192, 192, 0.4)" };
            var dataset2 = new LineScatterDataset() { Label = "Dataset 2", Data = new List<LineScatterData>(), BackgroundColor = "rgba(192, 75, 192, 0.4)" };

            dataset1.Data.Add(new LineScatterData() { x = "-10", y = "0" });
            dataset1.Data.Add(new LineScatterData() { x = "0", y = "10" });
            dataset1.Data.Add(new LineScatterData() { x = "10", y = "5" });

            dataset2.Data.Add(new LineScatterData() { x = "-5", y = "8" });
            dataset2.Data.Add(new LineScatterData() { x = "0", y = "12" });
            dataset2.Data.Add(new LineScatterData() { x = "10", y = "2" });

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset1);
            data.Datasets.Add(dataset2);

            chart.Data = data;

            Options options = new Options()
            {
                Scales = new Scales()
            };

            Scales scales = new Scales()
            {
                XAxes = new List<Scale>()
                {
                    new CartesianScale()
                    {
                        Type = "linear",
                        Position = "bottom",
                        Ticks = new CartesianLinearTick()
                        {
                            BeginAtZero = true
                        }
                    }
                }
            };

            options.Scales = scales;

            chart.Options = options;

            ViewData["chart"] = chart;

            return View();
        }

        public IActionResult Polar()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.PolarArea;

            Data data = new Data();
            data.Labels = new List<string>() { "Red", "Green", "Yellow", "Grey", "Blue" };

            PolarDataset dataset = new PolarDataset()
            {
                Label = "My dataset",
                BackgroundColor = new List<string>() { "#FF6384", "#4BC0C0", "#FFCE56", "#E7E9ED", "#36A2EB" },
                Data = new List<double>() { 11, 16, 7, 3, 14 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            string code = chart.CreateChartCode("polarChart");

            ViewData["chart"] = chart;

            return View();
        }

        public IActionResult Radar()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Radar;

            Data data = new Data();
            data.Labels = new List<string>() { "Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running" };

            RadarDataset dataset1 = new RadarDataset()
            {
                Label = "My First dataset",
                BackgroundColor = "rgba(179,181,198,0.2)",
                BorderColor = "rgba(179,181,198,1)",
                PointBackgroundColor = new List<string>() { "rgba(179,181,198,1)" },
                PointBorderColor = new List<string>() { "#fff" },
                PointHoverBackgroundColor = new List<string>() { "#fff" },
                PointHoverBorderColor = new List<string>() { "rgba(179,181,198,1)" },
                Data = new List<double>() { 65, 59, 80, 81, 56, 55, 40 }
            };

            RadarDataset dataset2 = new RadarDataset()
            {
                Label = "My Second dataset",
                BackgroundColor = "rgba(255,99,132,0.2)",
                BorderColor = "rgba(255,99,132,1)",
                PointBackgroundColor = new List<string>() { "rgba(255,99,132,1)" },
                PointBorderColor = new List<string>() { "#fff" },
                PointHoverBackgroundColor = new List<string>() { "#fff" },
                PointHoverBorderColor = new List<string>() { "rgba(255,99,132,1)" },
                Data = new List<double>() { 28, 48, 40, 19, 96, 27, 100 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset1);
            data.Datasets.Add(dataset2);

            chart.Data = data;

            string code = chart.CreateChartCode("radarChart");

            ViewData["chart"] = chart;

            return View();
        }

        public IActionResult Pie()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Pie;

            Data data = new Data();
            data.Labels = new List<string>() { "Red", "Blue", "Yellow" };

            PieDataset dataset = new PieDataset()
            {
                Label = "My dataset",
                BackgroundColor = new List<string>() { "#FF6384", "#36A2EB", "#FFCE56" },
                HoverBackgroundColor = new List<string>() { "#FF6384", "#36A2EB", "#FFCE56" },
                Data = new List<double>() { 300, 50, 100 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            string code = chart.CreateChartCode("pieChart");

            ViewData["chart"] = chart;

            return View();
        }

        public IActionResult Bubble()
        {
            Chart chart = new Chart();
            chart.Type = Enums.ChartType.Bubble;

            Data data = new Data();

            var dataset = new BubbleDataset() { Label = "Bubble Dataset", Data = new List<BubbleData>() };

            var random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                dataset.Data.Add(new BubbleData() {
                        x = random.Next(20, 40),
                        y = random.Next(10, 30),
                        r = random.Next(10, 20)
                    });
            }

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            dataset.BackgroundColor = new List<string>() { "#FF6384" };
            dataset.HoverBackgroundColor = new List<string>() { "#FF6384" };

            chart.Data = data;

            string code = chart.CreateChartCode("bubbleChart");

            ViewData["chart"] = chart;

            return View();
        }
    }
}
