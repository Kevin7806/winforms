﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.Design;

namespace System.Windows.Forms.PropertyGridInternal
{
    /// <summary>
    ///  This class contains the set of menu commands our property browser uses.
    /// </summary>
    public class PropertyGridCommands
    {
#pragma warning disable IDE1006 // Naming Styles - Shipped public API
        /// <summary>
        ///  This guid corresponds to the menu grouping windows forms will use for its menus.  This is
        ///  defined in the windows forms menu CTC file, but we need it here so we can define what
        ///  context menus to use.
        /// </summary>
        protected static readonly Guid wfcMenuGroup = new("{a72bd644-1979-4cbc-a620-ea4112198a66}");

        /// <summary>
        ///  This guid corresponds to the windows forms command set.
        /// </summary>
        protected static readonly Guid wfcMenuCommand = new("{5a51cf82-7619-4a5d-b054-47f438425aa7}");

        public static readonly CommandID Reset = new(wfcMenuCommand, 0x3000);
        public static readonly CommandID Description = new(wfcMenuCommand, 0x3001);
        public static readonly CommandID Hide = new(wfcMenuCommand, 0x3002);
        public static readonly CommandID Commands = new(wfcMenuCommand, 0x3010);
#pragma warning restore IDE1006 // Naming Styles
    }
}
