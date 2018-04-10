using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.QueryModel.BaseSet
{
    public class MaterialItems
    {
        public string ObjectID { get; set; }
        public string MaterialName { get; set; }
        public string UnitID { get; set; }
        public string UnitName { get; set; }
        public string IsEnable { get; set; }
        public string IsDelete { get; set; }

    }
}
