using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCAI.BL.Helper
{
    public class ApiResponse<type>
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public type Data { get; set; }
        public type Error { get; set; }
    }
}
