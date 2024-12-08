namespace WebAPI.Entities.Products;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Subcategory>? Subcategories { get; set; } = new List<Subcategory>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}