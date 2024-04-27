using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response.Login
{
    public class LoginSearchResponse
    {
        public int Id { get; set; }

        public int CampanaId { get; set; }

        public string Username { get; set; } = null!;
    }
}
