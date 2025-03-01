﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;

internal partial class Interop
{
    internal static partial class Shell32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct COMDLG_FILTERSPEC
        {
            public IntPtr pszName;
            public IntPtr pszSpec;
        }
    }
}
