﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms
{
    public partial class DataGridViewHeaderCell
    {
        private class DataGridViewHeaderCellRenderer
        {
            private static VisualStyleRenderer? s_visualStyleRenderer;

            private DataGridViewHeaderCellRenderer()
            {
            }

            public static VisualStyleRenderer VisualStyleRenderer
            {
                get
                {
                    if (s_visualStyleRenderer is null)
                    {
                        s_visualStyleRenderer = new VisualStyleRenderer(VisualStyleElement.Header.Item.Normal);
                    }

                    return s_visualStyleRenderer;
                }
            }
        }
    }
}
