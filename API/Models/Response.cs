using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Response
    {
        public bool Errored { get; set; }
        public string ErrorMessage { get; set; }
    }
}
