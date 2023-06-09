﻿using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wesley.BitImageEditor.Helper
{
    internal static class HapticFeedback
    {
        private static bool isSupportedVibrate = true;

        internal static void Excute()
        {
            if (isSupportedVibrate)
            {
                try
                {
                    if (Device.RuntimePlatform != Device.iOS)
                        Vibration.Vibrate(22);
                    else
                        DependencyService.Get<IHapticFeedback>().Excute();

                }
                catch { isSupportedVibrate = false; }
            }
        }
    }
}
