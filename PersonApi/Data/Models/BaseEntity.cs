using System.ComponentModel.DataAnnotations;

namespace PersonApi.Data.Models;

public abstract class BaseEntity
{
    [Key]
    public virtual int Id { get; set; }
}
