using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dto
{
    public class LoginDto
    {
        [Display(Name = "id")]
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter Username.")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter Password.")]
        public string password { get; set; }
    }
}
