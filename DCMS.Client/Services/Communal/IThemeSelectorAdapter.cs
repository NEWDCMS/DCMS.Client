﻿namespace DCMS.Client.Services
{
    public interface IThemeSelectorAdapter
    {
        string Theme { get; }

        void SetTheme(string theme);
    }
}
