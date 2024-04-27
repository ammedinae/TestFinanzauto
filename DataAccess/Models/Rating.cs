using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class Rating
{
    [Key]
    public long Id { get; set; }

    public long CourseId { get; set; }

    public long StudentId { get; set; }

    public long TeacherId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RegistrationDate { get; set; }

    public bool Active { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Ratings")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Ratings")]
    public virtual Student Student { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("Ratings")]
    public virtual Teacher Teacher { get; set; } = null!;
}
