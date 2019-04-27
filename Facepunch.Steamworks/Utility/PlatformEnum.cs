using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Facepunch.Steamworks.Utility
{
    public enum PlatformEnum
    {
        Windows,
        Linux,
        OSX,
        iOS,
        Android,
        PS4,
        Switch,
        Unknown
    }

    public static class PlatformUtility
    {

        private static PlatformEnum _platform = PlatformEnum.Unknown;

        public static PlatformEnum CurrentPlatform
        {
            get
            {
                if (_platform != PlatformEnum.Unknown)
                {
                    return _platform;
                }

                string windir = Environment.GetEnvironmentVariable("windir");
                if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
                {
                    _platform = PlatformEnum.Windows;
                }
                else if (File.Exists(@"/proc/sys/kernel/ostype"))
                {
                    string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                    if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
                    {
                        // TODO: Validate if Android.
                        _platform = PlatformEnum.Linux;
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unknown Unix based OS: {osType}");
                    }
                }
                else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
                {
                    // TODO: Validate if iOS.
                    _platform = PlatformEnum.OSX;
                }

                return _platform;
            }
            set { _platform = value; }
        }


    }
}
