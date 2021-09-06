using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.API
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new();
    }
}
