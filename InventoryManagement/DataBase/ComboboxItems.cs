using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.DataBase
{
    public class ComboboxItems
    {
        public ComboboxItems(string text, string value)
        {
            Text = text;
            Value = value;
        }


        public string Text { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Text;

        }
    }
}
