namespace WebAPI.Entities.Products;

public class Specification
{
    public required string Name { get; set; }
    public required List<string> Values {get;set;}
    
}
