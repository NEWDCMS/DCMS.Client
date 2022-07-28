﻿using Wesley.ChartJS;
using Wesley.ChartJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Wesley.Infrastructure.Helpers
{
    public class RandomChartBuilder
    {
        public static ChartViewConfig GetChartConfig(string chartType, Color color)
        {
            return new ChartViewConfig()
            {
                BackgroundColor = color,
                ChartConfig = new ChartConfig
                {
                    type = chartType,
                    data = GetChartData(new List<string> { chartType })
                }
            };
        }

        public static ChartViewConfig GetChartConfig(IEnumerable<string> chartTypes, Color color)
        {
            return new ChartViewConfig()
            {
                BackgroundColor = color,
                ChartConfig = new ChartConfig
                {
                    data = GetChartData(chartTypes)
                }
            };
        }

        public static ChartViewConfig GetBubbleChartConfig(Color color)
        {
            return new ChartViewConfig()
            {
                BackgroundColor = color,
                ChartConfig = new ChartConfig
                {
                    type = ChartTypes.Bubble,
                    data = new ChartData()
                    {
                        datasets = new List<ChartBubbleDataset>()
                        {
                            new ChartBubbleDataset
                            {
                                label = "Bubble Data",
                                data = new List<ChartBubbleDataPoint>()
                                {
                                    new ChartBubbleDataPoint { x = 20, y = 30, r = 15 },
                                    new ChartBubbleDataPoint { x = 40, y = 10, r = 10 }
                                },
                                backgroundColor = "rgb(255, 99, 132)"
                            }
                        }
                    }
                }
            };
        }

        public static ChartViewConfig GetScatterChartConfig(Color color)
        {
            return new ChartViewConfig()
            {
                BackgroundColor = color,
                ChartConfig = new ChartConfig
                {
                    type = ChartTypes.Scatter,
                    data = new ChartData()
                    {
                        datasets = new List<ChartScatterDataset>()
                        {
                            new ChartScatterDataset
                            {
                                label = "Scatter Data",
                                data = new List<ChartScatterDataPoint>()
                                {
                                    new ChartScatterDataPoint { x = -10, y = 0 },
                                    new ChartScatterDataPoint { x = 0, y = 10 },
                                    new ChartScatterDataPoint { x = 10, y = 5 },
                                    new ChartScatterDataPoint { x = 0.5, y = 5.5 }
                                },
                                backgroundColor = "rgb(255, 99, 132)"
                            }
                        }
                    }
                }
            };
        }

        private static ChartData GetChartData(IEnumerable<string> chartTypes)
        {
            var labels = new[] { "史绪安", "何元元", "肖刚", "蒋世兴", "王兴国", "刘静", "魏文昌", "王长华", "肖义", "胡兵" }.ToList();
            var dataSets = new List<ChartNumberDataset>();

            foreach (var chartType in chartTypes)
            {
                var colors = GetDefaultColors();
                var randomGen = new Random();
                var dataPoints = Enumerable.Range(0, labels.Count)
                    .Select(i => randomGen.Next(5, 50))
                    .ToList();

                var dataPoints2 = Enumerable.Range(0, labels.Count)
                .Select(i => randomGen.Next(1, 80))
                .ToList();

                dataSets.Add(new ChartNumberDataset
                {
                    type = chartType,
                    label = "今日拜访量",
                    data = dataPoints,
                    tension = 0.4,
                    backgroundColor = dataPoints.Select((d, i) =>
                    {
                        var color = colors[i % colors.Count];
                        return $"rgb({color.Item1},{color.Item2},{color.Item3})";
                    })
                });

                dataSets.Add(new ChartNumberDataset
                {
                    type = chartType,
                    label = "今日开单量",
                    data = dataPoints2,
                    tension = 0.4,
                    backgroundColor = dataPoints2.Select((d, i) =>
                    {
                        var color = colors[i % colors.Count];
                        return $"rgb({color.Item1},{color.Item2},{color.Item3})";
                    })
                });
            }

            return new ChartData()
            {
                datasets = dataSets,
                labels = labels
            };
        }

        public static List<Tuple<int, int, int>> GetDefaultColors()
        {
            return new List<Tuple<int, int, int>>
            {
                new Tuple<int, int, int>(255, 99, 132),
                new Tuple<int, int, int>(255, 159, 64),
                new Tuple<int, int, int>(255, 205, 86),
                new Tuple<int, int, int>(75, 192, 192),
                new Tuple<int, int, int>(54, 162, 235),
                new Tuple<int, int, int>(153, 102, 255),
                new Tuple<int, int, int>(201, 203, 207)
            };
        }
    }
}
