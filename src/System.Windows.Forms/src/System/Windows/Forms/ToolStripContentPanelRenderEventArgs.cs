﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Drawing;

namespace System.Windows.Forms
{
    public class ToolStripContentPanelRenderEventArgs : EventArgs
    {
        /// <summary>
        ///  This class represents all the information to render the toolStrip
        /// </summary>
        public ToolStripContentPanelRenderEventArgs(Graphics g, ToolStripContentPanel contentPanel)
        {
            Graphics = g.OrThrowIfNull();
            ToolStripContentPanel = contentPanel.OrThrowIfNull();
        }

        /// <summary>
        ///  The graphics object to draw with
        /// </summary>
        public Graphics Graphics { get; }

        /// <summary>
        ///  Represents which toolStrip was affected by the click
        /// </summary>
        public ToolStripContentPanel ToolStripContentPanel { get; }

        public bool Handled { get; set; }
    }
}
