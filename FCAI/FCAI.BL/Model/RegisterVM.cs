using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Model
{
    public class RegisterVM
    {

        [Required(ErrorMessage = "User Name Required")]
        [MinLength(3,ErrorMessage = "User Name Min len 3")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage ="In Valid Mail")]
        [Required(ErrorMessage ="Mail Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [MinLength(6,ErrorMessage ="Min Len 6")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        [Compare("Password",ErrorMessage = "Password Not match")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
    }
}
