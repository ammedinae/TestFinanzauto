using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class AppSettings
    {
        public string? Policy { get; set; }
        public string? OriginCors { get; set; }
        public string? Secret { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
