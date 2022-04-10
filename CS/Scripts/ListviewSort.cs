﻿using System.Collections;
using System.Windows.Forms;

namespace ADSearch.Scripts
{
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListviewSort : IComparer  
    {
        private int columnToSort;  // Specifies the column to be sorted
        private SortOrder orderOfSort;  // Specifies the order in which to sort (i.e. 'Ascending').
        private readonly CaseInsensitiveComparer objectCompare;  // Case insensitive comparer object

        /// <summary>
        /// sort the listview by column
        /// http://support.microsoft.com/kb/319401
        /// </summary>
        public ListviewSort() // Class constructor.  Initializes various elements
        {
            columnToSort = 0;
            orderOfSort = SortOrder.None;
            objectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        ///  This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = objectCompare.Compare(listviewX.SubItems[columnToSort].Text, listviewY.SubItems[columnToSort].Text);

            // Calculate correct return value based on object comparison
            if (orderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (orderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                columnToSort = value;
            }
            get
            {
                return columnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                orderOfSort = value;
            }
            get
            {
                return orderOfSort;
            }
        }

    }
}
