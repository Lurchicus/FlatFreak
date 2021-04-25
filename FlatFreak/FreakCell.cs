using System;

namespace FlatFreak
{
    /// <summary>
    /// The freak cell contains a string and a count of how many times the
    /// string has been referenced. This lets us create a frequency report
    /// on a list of freak cells.
    /// </summary>
    public class FreakCell
    {
        /// <summary>
        /// Value is a unique string and Count is the number of times the
        /// string has been referenced.
        /// </summary>
        private string Value = String.Empty;
        private Int32 Count = 0;

        /// <summary>
        /// Create a new FreakCell instance. Save the string in Item into
        /// Value and initialize the count to 1 reference
        /// </summary>
        /// <param name="Item">A unique string</param>
        public void New(string Item)
        {
            Value = Item;
            Count = 1;
        }

        /// <summary>
        /// Add additional references to the unique string in Item if it
        /// matches the string stored in Value
        /// </summary>
        /// <param name="Item">A unique string</param>
        public void Add(string Item)
        {
            if (Item == Value)
            {
                Count++;
            }
            else
            {
                if (Value.Length == 0 & Item.Length > 0)
                {
                    Value = Item;
                    Count++;
                }
            }
        }

        /// <summary>
        /// Returns the unique string stored in Value
        /// </summary>
        /// <returns>string Value</returns>
        public string GetValue
        {
            get { return Value; }
        }

        /// <summary>
        /// Returns the count of how many times the string in Value has been
        /// referenced
        /// </summary>
        /// <returns>Int32 Count</returns>
        public Int32 GetCount
        {
            get { return Count; }
        }
    }
}
