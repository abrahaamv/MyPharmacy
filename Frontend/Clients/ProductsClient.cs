using Frontend.Models;

namespace Frontend.Clients;

public class ProductsClient(HttpClient httpClient)
{
    private readonly List<ProductSummary> products = [
    new()
    {
        Id = 1,
        Ean = "7401156002031",
        Name = "Bicarbonato De Soda Disfavil- 1 Libra",
        Slug = "bicarbonato-1-libra",
        Brand = "DISFAVIL",
        Category = "Sistema digestivo y Antiparasitarios",
        SubCategory = "Sueros",
        ListPrice = 11.00M,
        IsInStock = true,
        ImageUrls = [
            "https://walmartgt.vtexassets.com/arquivos/ids/227099/Bicarbonato-De-Soda-Disfavil-1-Libra-1-30480.jpg"
        ]
    },
    new()
    {
        Id = 156,
        Ean = "0011418215085",
        Name = "Alka Gastric X 12 Tabletas Masticables",
        Slug = "alka-gastric-12-tabletas",
        Brand = "ALKA GASTRIC",
        Category = "Sistema digestivo y Antiparasitarios",
        SubCategory = "Sueros",
        ListPrice = 35.75M,
        SellingPrice = 31.95M,
        IsInStock = true,
        ImageUrls = [
            "https://walmartgt.vtexassets.com/arquivos/ids/550127/873_01.jpg"
        ]
    },
    new()
    {
        Id = 165,
        Ean = "7406048002335",
        Name = "S Lacto Menarini Digestomen 100 Cápsulas - Precio indicado por cápsula",
        Slug = "s-lacto-menarini-digestomen-100-capsulas",
        Brand = "MENARINI",
        Category = "Sistema digestivo y Antiparasitarios",
        SubCategory = "Sueros",
        ListPrice = 5.10M,
        SellingPrice = 5.10M,
        IsInStock = true,
        ImageUrls = [
            "https://walmartgt.vtexassets.com/arquivos/ids/306261/S-Lacto-Menarini-Digestomen-100-C-psulas-Precio-indicado-por-c-psula-1-54402.jpg"
        ]
    },
    new()
    {
        Id = 167,
        Ean = "0706020100897",
        Name = "Pk Principal Forte 60 + 15 Tabletas Una Caja",
        Slug = "pk-principal-forte-60-15-tabletas",
        Brand = "DONOVAN",
        Category = "Sistema digestivo y Antiparasitarios",
        SubCategory = "Sueros",
        ListPrice = 221.00M,
        SellingPrice = 221.00M,
        IsInStock = true,
        ImageUrls = [
            "https://walmartgt.vtexassets.com/arquivos/ids/180655/Pk-Principal-Forte-60-15-Tabletas-1-13450.jpg"
        ]
    },
    new()
    {
        Id = 198,
        Ean = "7350012550394",
        Name = "Gotas Probioticas Biogaia Protectis 100 Millones Ufc De Lactobacillus Reuteri Cepa Dsm 17938 5Ml",
        Slug = "biogaia-gotas-5-ml",
        Brand = "ALDO UNION",
        Category = "Sistema digestivo y Antiparasitarios",
        SubCategory = "Sueros",
        ListPrice = 190.00M,
        SellingPrice = 190.00M,
        IsInStock = true,
        ImageUrls = [
            "https://walmartgt.vtexassets.com/arquivos/ids/252676/Biogaia-Gotas-5-Ml-1-26633.jpg"
        ]
    },
    new()
    {
        Id = 244,
        Ean = "7401107033121",
        Name = "Levusol Diabetico Coco 475Ml",
        Slug = "levusol-diabetico-coco-475ml",
        Brand = "FRYCIA",
        Category = "Sistema digestivo y Antiparasitarios",
        SubCategory = "Sueros",
        ListPrice = 17.75M,
        SellingPrice = 17.75M,
        IsInStock = true,
        ImageUrls = [
            "https://walmartgt.vtexassets.com/arquivos/ids/327199/Levusol-Diabetico-Coco-475Ml-1-29950.jpg"
        ]
    },
    new()
    {
        Id = 277,
        Ean = "7501088500114",
        Name = "Laxante Anara -5 Mg - Precio Indicado por Unidad -",
        Slug = "anara-5mg-x50-sobre",
        Brand = "CHINOIN",
        Category = "Sistema digestivo y Antiparasitarios",
        SubCategory = "Sueros",
        ListPrice = 7.80M,
        SellingPrice = 7.80M,
        IsInStock = true,
        ImageUrls = [
            "https://walmartgt.vtexassets.com/arquivos/ids/256086/Laxante-Anara-5-Mg-1-36680.jpg"
        ]
    },
    new()
    {
        Id = 280,
        Ean = "7401107033022",
        Name = "Electrolitos Alfa Farmacéutica Levusol Frycia Diabetico Manzana - 475ml",
        Slug = "levusol-frycia-diabetico-manzana-475ml",
        Brand = "FRYCIA",
        Category = "Sistema digestivo y Antiparasitarios",
        SubCategory = "Sueros",
        ListPrice = 17.75M,
        SellingPrice = 17.75M,
        IsInStock = true,
        ImageUrls = [
            "https://walmartgt.vtexassets.com/arquivos/ids/338676/Electrolitos-Alfa-Farmac-utica-Levusol-Frycia-Diabetico-Manzana-475ml-1-29949.jpg"
        ]
    },
    new()
    {
        Id = 292,
        Ean = "7401107033220",
        Name = "Levusol Diabetico Cereza 475Ml",
        Slug = "levusol-diabetico-cereza-475ml",
        Brand = "FRYCIA",
        Category = "Sistema digestivo y Antiparasitarios",
        SubCategory = "Sueros",
        ListPrice = 17.35M,
        SellingPrice = 17.35M,
        IsInStock = true,
        ImageUrls = [
            "https://walmartgt.vtexassets.com/arquivos/ids/195253/Levusol-Diabetico-Cereza-475Ml-1-29951.jpg"
        ]
    }
];

    public ProductSummary[] GetProducts() => [..products];
}