﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System.Collections;
using System.Diagnostics;

namespace System.Windows.Forms
{
    /// <summary>
    ///  Represents a linked list of <see cref="DataGridViewCell"/> objects
    /// </summary>
    internal class DataGridViewCellLinkedList : IEnumerable
    {
        private DataGridViewCellLinkedListElement lastAccessedElement;
        private DataGridViewCellLinkedListElement headElement;
        private int count, lastAccessedIndex;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DataGridViewCellLinkedListEnumerator(headElement);
        }

        public DataGridViewCellLinkedList()
        {
            lastAccessedIndex = -1;
        }

        public DataGridViewCell this[int index]
        {
            get
            {
                Debug.Assert(index >= 0);
                Debug.Assert(index < count);
                if (lastAccessedIndex == -1 || index < lastAccessedIndex)
                {
                    DataGridViewCellLinkedListElement tmp = headElement;
                    int tmpIndex = index;
                    while (tmpIndex > 0)
                    {
                        tmp = tmp.Next;
                        tmpIndex--;
                    }

                    lastAccessedElement = tmp;
                    lastAccessedIndex = index;
                    return tmp.DataGridViewCell;
                }
                else
                {
                    while (lastAccessedIndex < index)
                    {
                        lastAccessedElement = lastAccessedElement.Next;
                        lastAccessedIndex++;
                    }

                    return lastAccessedElement.DataGridViewCell;
                }
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public DataGridViewCell HeadCell
        {
            get
            {
                Debug.Assert(headElement is not null);
                return headElement.DataGridViewCell;
            }
        }

        public void Add(DataGridViewCell dataGridViewCell)
        {
            Debug.Assert(dataGridViewCell is not null);
            Debug.Assert(dataGridViewCell.DataGridView.SelectionMode == DataGridViewSelectionMode.CellSelect ||
                         dataGridViewCell.DataGridView.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect ||
                         dataGridViewCell.DataGridView.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect);
            DataGridViewCellLinkedListElement newHead = new DataGridViewCellLinkedListElement(dataGridViewCell);
            if (headElement is not null)
            {
                newHead.Next = headElement;
            }

            headElement = newHead;
            count++;
            lastAccessedElement = null;
            lastAccessedIndex = -1;
        }

        public void Clear()
        {
            lastAccessedElement = null;
            lastAccessedIndex = -1;
            headElement = null;
            count = 0;
        }

        public bool Contains(DataGridViewCell dataGridViewCell)
        {
            Debug.Assert(dataGridViewCell is not null);
            int index = 0;
            DataGridViewCellLinkedListElement tmp = headElement;
            while (tmp is not null)
            {
                if (tmp.DataGridViewCell == dataGridViewCell)
                {
                    lastAccessedElement = tmp;
                    lastAccessedIndex = index;
                    return true;
                }

                tmp = tmp.Next;
                index++;
            }

            return false;
        }

        public bool Remove(DataGridViewCell dataGridViewCell)
        {
            Debug.Assert(dataGridViewCell is not null);
            DataGridViewCellLinkedListElement tmp1 = null, tmp2 = headElement;
            while (tmp2 is not null)
            {
                if (tmp2.DataGridViewCell == dataGridViewCell)
                {
                    break;
                }

                tmp1 = tmp2;
                tmp2 = tmp2.Next;
            }

            if (tmp2.DataGridViewCell == dataGridViewCell)
            {
                DataGridViewCellLinkedListElement tmp3 = tmp2.Next;
                if (tmp1 is null)
                {
                    headElement = tmp3;
                }
                else
                {
                    tmp1.Next = tmp3;
                }

                count--;
                lastAccessedElement = null;
                lastAccessedIndex = -1;
                return true;
            }

            return false;
        }

        public int RemoveAllCellsAtBand(bool column, int bandIndex)
        {
            int removedCount = 0;
            DataGridViewCellLinkedListElement tmp1 = null, tmp2 = headElement;
            while (tmp2 is not null)
            {
                if ((column && tmp2.DataGridViewCell.ColumnIndex == bandIndex) ||
                    (!column && tmp2.DataGridViewCell.RowIndex == bandIndex))
                {
                    DataGridViewCellLinkedListElement tmp3 = tmp2.Next;
                    if (tmp1 is null)
                    {
                        headElement = tmp3;
                    }
                    else
                    {
                        tmp1.Next = tmp3;
                    }

                    tmp2 = tmp3;
                    count--;
                    lastAccessedElement = null;
                    lastAccessedIndex = -1;
                    removedCount++;
                }
                else
                {
                    tmp1 = tmp2;
                    tmp2 = tmp2.Next;
                }
            }

            return removedCount;
        }
    }
}
