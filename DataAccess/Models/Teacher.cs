using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class Teacher
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

    [Column(TypeName = "datetime")]
    public DateTime RegistrationDate { get; set; }

    public bool Active { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
