﻿using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
namespace Wesley.Client.Pages.CustomControls
{

    public partial class FloatingButton : PancakeView
    {
        #region PressedCommand
        public static readonly BindableProperty PressedCommandProperty = BindableProperty.Create(nameof(PressedCommand), typeof(ICommand), typeof(FloatingButton), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as FloatingButton;
            if (newV != null && !(newV is ICommand)) return;
            var oldPressedCommand = (ICommand)old;
            var newPressedCommand = (ICommand)newV;
            me?.PressedCommandChanged(oldPressedCommand, newPressedCommand);
        });

        private void PressedCommandChanged(ICommand oldPressedCommand, ICommand newPressedCommand)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public ICommand PressedCommand
        {
            get => (ICommand)GetValue(PressedCommandProperty);
            set => SetValue(PressedCommandProperty, value);
        }
        #endregion

        #region FontSize
        public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(float), typeof(FloatingButton), defaultValue: 20f, propertyChanged: (obj, old, newV) =>
        {
            var me = obj as FloatingButton;
            if (newV != null && !(newV is float)) return;
            var oldIconSize = (float)old;
            var newIconSize = (float)newV;
            me?.IconSizeChanged(oldIconSize, newIconSize);
        });

        private void IconSizeChanged(float oldIconSize, float newIconSize)
        {
        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public float FontSize
        {
            get => (float)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }
        #endregion

        #region Icon
        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(String), typeof(FloatingButton), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as FloatingButton;
            if (newV != null && !(newV is String)) return;
            var oldIcon = (String)old;
            var newIcon = (String)newV;
            me?.IconChanged(oldIcon, newIcon);
        });

        private void IconChanged(String oldIcon, String newIcon)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public String Icon
        {
            get => (String)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        #endregion

        #region TextColor
        public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(FloatingButton), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as FloatingButton;
            if (newV != null && !(newV is Color)) return;
            var oldIconColor = (Color)old;
            var newIconColor = (Color)newV;
            me?.IconColorChanged(oldIconColor, newIconColor);
        });

        private void IconColorChanged(Color oldIconColor, Color newIconColor)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public Color TextColor
        {
            get => (Color)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }
        #endregion

        public FloatingButton()
        {
            InitializeComponent();
        }
    }
}