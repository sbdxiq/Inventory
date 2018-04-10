using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.QueryModel.Inventory
{
    public class CurrentInventoryItems
    {
        public string ObjectID { get; set; }
        public string MaterialID { get; set; }
        public string MaterialName { get; set; }
        public string UnitName { get; set; }
        public int CurrentCount { get; set; }

    }
}
