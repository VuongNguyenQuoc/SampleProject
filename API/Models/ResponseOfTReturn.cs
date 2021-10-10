using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public sealed class Response<TReturn> : Response
    {
        public TReturn Object { get; set; }
    }
}
