using System.ComponentModel.DataAnnotations;

namespace BlazorServer.DataAccess.Models.BaseEntity
{
    public abstract class BaseEntity<TId>
    {
        [Key]
        public virtual TId Id { get; set; }
    }
}
