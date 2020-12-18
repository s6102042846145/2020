using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dto.Admin
{
    public class ContentListDto
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string contents { get; set; }
        public string contents_mobile { get; set; }
        public int skin_directory { get; set; }
        public int skin_directory_mobile { get; set; }
        public string include_head { get; set; }
        public string include_tail { get; set; }
        public string img_head { get; set; }
        public string img_tail { get; set; }
        public int active { get; set; }
    }
}
