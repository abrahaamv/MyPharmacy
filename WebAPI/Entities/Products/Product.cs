namespace WebAPI.Entities.Products;

public class Product
{
    public int Id { get; set; }
    public required string Ean { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Slug { get; set; }
    //BRAND
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
    //CATEGORY
    public required int CategoryId { get; set; }
    public Category? Category { get; set; }
    //SUBCATEGORY
    public int? SubCategoryId { get; set; }
    public SubCategory? SubCategory { get; set; }
    //PRICE
    public decimal ListPrice { get; set; }
    public decimal SellingPrice { get; set; }
    //AVAILABLE QUANTITY
    public int Stock { get; set; }
    public bool IsInStock => Stock > 0;
    //IMAGES
    public required List<string> ImageUrls { get; set; }
    //PRODUCT SPECIFICATIONS
    public List<Specification>? Specifications { get; set; }
}

