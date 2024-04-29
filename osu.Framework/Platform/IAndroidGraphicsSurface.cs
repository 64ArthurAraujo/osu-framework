﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace osu.Framework.Platform
{
    public interface IAndroidGraphicsSurface
    {
        /// <summary>
        /// Returns JNI environment handle.
        /// </summary>
        IntPtr JniEnvHandle { get; }
    }
}
