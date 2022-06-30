using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Core.Dtos.Outputs
{
    public class AssistanceDayDto
    {
        public DateTime Date { get; set; }
        public string AssitanceStatus { get; set; }
        public object Entry { get; set; }
    }
}