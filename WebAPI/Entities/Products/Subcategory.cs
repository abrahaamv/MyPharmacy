namespace WebAPI.Entities.Products;

public class Subcategory
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CategoryId { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();

}
