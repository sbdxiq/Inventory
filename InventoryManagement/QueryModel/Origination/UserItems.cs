using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.QueryModel.Origination
{
    public class UserItems
    {
        public string ObjectID { get; set; }
        public string UserName { get; set; }
        public string UserDepartmentID { get; set; }
        public string UserDepartmentName { get; set; }
        public string IsEnable { get; set; }
        public string IsDelete { get; set; }
    }
}
