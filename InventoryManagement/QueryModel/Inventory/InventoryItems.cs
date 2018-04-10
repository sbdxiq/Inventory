using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.QueryModel.Inventory
{
    public class InventoryItems
    {

        public string ObjectID { get; set; }
        public string MaterialID { get; set; }
        public string UserID { get; set; }
        public double Price { get; set; }
        public double Number { get; set; }
        public double CreatedTime { get; set; }
        public string Mark { get; set; }

    }
}
