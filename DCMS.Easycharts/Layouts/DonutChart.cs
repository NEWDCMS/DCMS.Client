﻿namespace DCMS.Easycharts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SkiaSharp;

    /// <summary>
    ///  圆环图表
    /// </summary>
    public class DonutChart : Chart
    {
        #region Properties

        /// <summary>
        /// Gets or sets the radius of the hole in the center of the chart.
        /// </summary>
        /// <value>The hole radius.</value>
        public float HoleRadius { get; set; } = 0.5f;

        #endregion

        #region Methods

        /// <summary>
        /// 绘制内容
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            if (this.Entries != null)
            {
                this.DrawCaption(canvas, width, height);
                using (new SKAutoCanvasRestore(canvas))
                {
                    canvas.Translate(width / 2, height / 2);
                    var sumValue = this.Entries.Sum(x => Math.Abs(x.Value));
                    var radius = (Math.Min(width, height) - (2 * Margin)) / 2;

                    var start = 0.0f;
                    for (int i = 0; i < this.Entries.Count(); i++)
                    {
                        var entry = this.Entries.ElementAt(i);
                        var end = start + ((Math.Abs(entry.Value) / sumValue) * this.AnimationProgress);

                        // Sector
                        var path = RadialHelpers.CreateSectorPath(start, end, radius, radius * this.HoleRadius);
                        using (var paint = new SKPaint
                        {
                            Style = SKPaintStyle.Fill,
                            Color = entry.Color,
                            IsAntialias = true,
                        })
                        {
                            canvas.DrawPath(path, paint);
                        }

                        start = end;
                    }
                }
            }
        }

        /// <summary>
        /// 绘制标题
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DrawCaption(SKCanvas canvas, int width, int height)
        {
            var sumValue = this.Entries.Sum(x => Math.Abs(x.Value));
            var rightValues = new List<ChartEntry>();
            var leftValues = new List<ChartEntry>();

            int i = 0;
            var current = 0.0f;
            while (i < this.Entries.Count() && (current < sumValue / 2))
            {
                var entry = this.Entries.ElementAt(i);
                rightValues.Add(entry);
                current += Math.Abs(entry.Value);
                i++;
            }

            while (i < this.Entries.Count())
            {
                var entry = this.Entries.ElementAt(i);
                leftValues.Add(entry);
                i++;
            }

            leftValues.Reverse();

            this.DrawCaptionElements(canvas, width, height, rightValues, false);
            this.DrawCaptionElements(canvas, width, height, leftValues, true);
        }

        #endregion
    }
}