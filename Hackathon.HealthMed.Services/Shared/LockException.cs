using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Shared
{
    public class LockException : Exception
    {
        public LockException(string message) : base(message)
        {
        }
    }
}
