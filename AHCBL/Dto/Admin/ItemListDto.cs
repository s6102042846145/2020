using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dto.Admin
{
    public class ItemListDto
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string price_win { get; set; }
        public string buy_name { get; set; }
        public string win_date { get; set; }
        public string status { get; set; }
    }
}
