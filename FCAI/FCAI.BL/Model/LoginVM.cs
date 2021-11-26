using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Model
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage = "In Valid Mail")]
        [Required(ErrorMessage = "Mail Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
