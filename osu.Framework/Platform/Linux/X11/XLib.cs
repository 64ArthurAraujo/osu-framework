#pragma warning disable IDE0073 // The file header is missing or not located at the top of the file

using System;
using System.Collections.Generic;
using osu.Framework.Logging;
using X11;
using static X11.Xlib;

namespace osu.Framework.Platform.Linux.X11
{
    /// <summary>
    /// A general class that provides X11 utilities.
    /// </summary>
    public static class XUtils
    {

        /// <summary>
        /// Lists all the top-level windows for the specified display.
        /// </summary>
        public static List<Window> ListWindows(IntPtr display)
        {
            Window rootReturn = 0, parentReturn = 0;

            int result = XQueryTree(display, XDefaultRootWindow(display), ref rootReturn, ref parentReturn, out var childrenReturn);

            if (result == 0)
            {
                Logger.Log("[XUtils] XQueryTree returned 0");
                return [];
            }

            return childrenReturn;
        }
    }
}