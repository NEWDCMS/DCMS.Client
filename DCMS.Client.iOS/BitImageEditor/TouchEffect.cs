﻿
using DCMS.BitImageEditor.TouchTracking;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName(TouchEffect.resolutionGroupName)]
[assembly: ExportEffect(typeof(DCMS.BitImageEditor.IOS.TouchTracking.TouchEffect), TouchEffect.uniqueName)]
namespace DCMS.BitImageEditor.IOS.TouchTracking
{
    internal class TouchEffect : PlatformEffect
    {
        private UIView view;
        private TouchRecognizer touchRecognizer;

        protected override void OnAttached()
        {
            // Get the iOS UIView corresponding to the Element that the effect is attached to
            view = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the .NET Standard library
            DCMS.BitImageEditor.TouchTracking.TouchEffect effect = (DCMS.BitImageEditor.TouchTracking.TouchEffect)Element.Effects.FirstOrDefault(e => e is DCMS.BitImageEditor.TouchTracking.TouchEffect);

            if (effect != null && view != null)
            {
                // Create a TouchRecognizer for this UIView
                touchRecognizer = new TouchRecognizer(Element, view, effect);
                view.AddGestureRecognizer(touchRecognizer);
            }
        }

        protected override void OnDetached()
        {
            if (touchRecognizer != null)
            {
                // Clean up the TouchRecognizer object
                touchRecognizer.Detach();

                // Remove the TouchRecognizer from the UIView
                view.RemoveGestureRecognizer(touchRecognizer);
            }
        }
    }
}