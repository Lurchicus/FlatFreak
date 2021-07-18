using System;
using System.Collections.Generic;

namespace FlatFreak
{
    /// <summary>
    ///
    /// </summary>
    internal class FreakList
    {
        private Int32 MaxItemLength;

        /// <summary>
        /// A list of FreakCell objects
        /// </summary>
        public static List<FreakCell> CellList = new List<FreakCell> { };

        /// <summary>
        /// Constructor creates a new empty instance of FreakList (a list of
        /// FreakCell objects)
        /// </summary>
        public void New()
        {
            Items = 0;
            AddedItem = 0;
        }

        /// <summary>
        /// Overload constructor creates a new instance of FreakList (a list
        /// of FreakCell object) with one initial item in Item
        /// </summary>
        /// <param name="Item">A unique string</param>
        public void New(string Item)
        {
            Items = 0;
            AddedItem = 0;
            if (Item.Length > 0)
            {
                Add(Item);
            }
        }

        /// <summary>
        /// Add a new item to the FreakList if it doesn't already exist. If it
        /// does exist, just bump its reference counter by 1
        /// </summary>
        /// <param name="Item"></param>
        public void Add(string Item)
        {
            bool Added = false;
            if (Items == 0)
            {
                Added = false;
            }
            else
            {
                //Scan through the list of FreakCells to see if the string in
                // Item has been added yet, if it has, increment the count.
                for (int Index = 0; Index < CellList.Count; Index++)
                {
                    if (CellList[Index].GetValue == Item)
                    {
                        CellList[Index].Add(Item);
                        Added = true;
                        AddedItem++;
                    }
                }
            }
            if (Added == false)
            {
                //Add a new unique item
                if (Item.Length > MaxItemLength)
                {
                    MaxItemLength = Item.Length;
                }
                FreakCell Cell = new FreakCell { };
                Cell.Add(Item);
                CellList.Add(Cell);
                Items++;
                AddedItem++;
            }
        }

        /// <summary>
        /// Sort the FreakList by value (string) with a simple bubble sort (they're easy to write okay?)
        /// </summary>
        public void Sort()
        {
            bool Sorted = false;
            FreakCell temp;
            if (Items >= 2)
            {
                while (!Sorted)
                {
                    Sorted = true;
                    for (int Index = 0; Index < CellList.Count - 1; Index++)
                    {
                        if (string.Compare(CellList[Index].GetValue, CellList[Index + 1].GetValue) > 0)
                        {
                            temp = CellList[Index];
                            CellList[Index] = CellList[Index + 1];
                            CellList[Index + 1] = temp;
                            Sorted = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Return the add count (cells and increments)
        /// </summary>
        public Int32 AddedItem { get; private set; } = 0;

        /// <summary>
        /// Return the cell count
        /// </summary>
        public Int32 Items { get; private set; } = 0;

        /// <summary>
        /// Return the item in the cell
        /// </summary>
        /// <param name="Index">Cell index in the list object</param>
        /// <returns>The cell item at index</returns>
        public string GetCellItem(Int32 Index)
        {
            string ret = "";
            if (Index >= 0)
            {
                if (Index <= CellList.Count)
                {
                    ret = CellList[Index].GetValue;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets the cell count at index
        /// </summary>
        /// <param name="Index">Cell list index</param>
        /// <returns>Cell count at index</returns>
        public Int32 GetCellCount(Int32 Index)
        {
            Int32 ret = 0;
            if (Index >= 0)
            {
                if (Index <= CellList.Count)
                {
                    ret = CellList[Index].GetCount;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets the maximum item size (string length)
        /// </summary>
        /// <returns></returns>
        public Int32 GetMaxItemLength()
        {
            return MaxItemLength;
        }

        /// <summary>
        /// Clear out the list object containing the FreakCells (does not
        /// close out the FreakList class)
        /// </summary>
        public void ClearList()
        {
            if (CellList != null)
            {
                CellList.Clear();
                CellList = null;
            }
        }
    }
}