using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Result
{
    public class UserResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
