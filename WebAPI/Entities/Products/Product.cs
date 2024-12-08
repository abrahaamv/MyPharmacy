using System.ComponentModel.DataAnnotations.Schema;

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
    public required Brand Brand { get; set; }
    //CATEGORY
    public int CategoryId { get; set; }
    public required Category Category { get; set; }
    //SUBCATEGORY
    public int? SubCategoryId { get; set; }
    public Subcategory? SubCategory { get; set; }
    //PRODUCT SPECIFICATIONS
    [NotMapped]
    public List<Specification>? Specifications { get; set; }
    public required List<string> ImageUrls { get; set; }
    //PRICE
    public decimal ListPrice { get; set; }
    public decimal SellPrice { get; set; }
    //AVAILABLE QUANTITY
    public int Stock { get; set; }
    public bool IsInStock => Stock > 0;
}