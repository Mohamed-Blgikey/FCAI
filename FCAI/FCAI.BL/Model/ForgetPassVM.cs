using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Model
{
    public class ForgetPassVM
    {
        [EmailAddress(ErrorMessage = "In Valid Mail")]
        [Required(ErrorMessage = "Mail Required")]
        public string Email { get; set; }
    }
}
