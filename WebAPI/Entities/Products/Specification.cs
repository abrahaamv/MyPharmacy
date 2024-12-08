using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities.Products;

[NotMapped]
public class Specification
{
    public required string Name { get; set; }
    public required string Value {get;set;}
    
}
