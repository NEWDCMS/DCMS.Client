﻿using Android.Content;
using AndroidX.Core.View;
using DCMS.Client.Droid.Renderers;
using DCMS.Client.RenderedViews;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FrameRenderer = Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer;

[assembly: ExportRenderer(typeof(MaterialFrame), typeof(AndroidMaterialFrameRenderer))]
namespace DCMS.Client.Droid.Renderers
{
    /// <summary>
    /// Renderer to update all frames with better shadows matching material design standards.
    /// </summary>
    public class AndroidMaterialFrameRenderer : FrameRenderer
    {
        public AndroidMaterialFrameRenderer(Context context)
            : base(context)
        {
        }

        private MaterialFrame MaterialFrame => (MaterialFrame)Element;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(MaterialFrame.Elevation))
            {
                UpdateElevation();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            UpdateElevation();
        }

        private void UpdateElevation()
        {
            // we need to reset the StateListAnimator to override the setting of Elevation on touch down and release.
            Control.StateListAnimator = new Android.Animation.StateListAnimator();

            // set the elevation manually
            ViewCompat.SetElevation(this, MaterialFrame.Elevation);
            ViewCompat.SetElevation(Control, MaterialFrame.Elevation);
        }
    }
}