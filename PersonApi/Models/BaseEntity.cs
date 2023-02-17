using System.ComponentModel.DataAnnotations;

namespace PersonApi.Models;

public abstract class BaseEntity
{
    [Key]
    public virtual int Id { get; set; }    
}
