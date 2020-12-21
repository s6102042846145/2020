using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Component.Common
{
    public class EUser
    {
        public int member_id { get; set; }
        public string UserIP { get; set; }
        public string UserID { get; set; }
        public DateTime Login { get; set; }
        public string UserName { get; set; }
        public string IbcCode { get; set; }
        public bool IS_APPROVE { get; set; }
        public bool IS_BOND { get; set; }
        public bool IS_Admin { get; set; }
        public string System { get; set; }
        public string Channel { get; set; }
        public bool IS_Admin_Checker { get; set; }
        public bool IS_Supper_Admin { get; set; }
        public bool IS_Admin_Maker { get; set; }
        public bool lelvel { get; set; }
    }
}
