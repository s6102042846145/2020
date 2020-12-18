using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dto.Admin
{
    public class CategoryListDto
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string min_price { get; set; }
        public string max_price { get; set; }
        public string charging_time { get; set; }
        public int energy { get; set; }
        public int revenue { get; set; }
        public int day { get; set; }
        public int win_count { get; set; }
        public string win_max_price { get; set; }
        public string ca_order { get; set; }
        public bool ca_use { get; set; }
        public int active { get; set; }

    }
}
