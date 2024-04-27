using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request
{
    public class StudentRequest
    {
        [Key]
        public long Id { get; set; }

        [StringLength(11)]
        [Unicode(false)]
        public string Document { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string Names { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string Surname { get; set; } = null!;

        [StringLength(12)]
        [Unicode(false)]
        public string Phone { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; } = null!;

        public bool? Active { get; set; }
    }
}
