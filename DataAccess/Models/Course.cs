using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class Course
{
    [Key]
    public long Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NameCourse { get; set; } = null!;

    public byte Hourlyintensity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RegistrationDate { get; set; }

    public bool Active { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
