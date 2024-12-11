# This script processes and transforms raw product data obtained from the Walmart Guatemala API.
# It extracts relevant fields, formats the data, and prepares it to be used in our API.
# The transformed data is then saved to a new JSON file for further use or integration.


import json

def transform_products(products):
    """
    Transforms raw product data into a standardized format for use in our API.
    Extracts and maps relevant fields such as prices, categories, and specifications.
    """
    transformed = []

    for product in products:
        # Extract product details with safe fallback to default values
        ean = product.get("items", [{}])[0].get("ean", "")
        images = product.get("items", [{}])[0].get("images", [])
        selling_price = product.get("priceRange", {}).get("sellingPrice", {}).get("highPrice", 0)
        list_price = product.get("priceRange", {}).get("listPrice", {}).get("highPrice", 0)
        available_quantity = product.get("items", [{}])[0].get("sellers", [{}])[0].get("commertialOffer", {}).get("AvailableQuantity", 0)
        
        # Extract specifications specific to the "Farmacia" category
        specifications = next(
            (sg.get("specifications", []) for sg in product.get("specificationGroups", []) if sg.get("name") == "Farmacia"), []
        )
        
        # Map the extracted data to a standardized format
        transformed_product = {
            "id": ean,  # Unique identifier for the product
            "sku": ean,  # SKU for inventory management
            "Name": product.get("productName", ""),  # Product name
            "description": product.get("description", ""),  # Product description
            "slug": product.get("linkText", ""),  # URL-friendly product name
            "brand": product.get("brand", ""),  # Brand name
            "brandId": product.get("brandId", 0),  # Brand ID
            "categories": product.get("categories", []),  # Product categories
            "listPrice": list_price,  # Original price
            "sellingPrice": selling_price,  # Current price
            "images": images,  # Product images
            "availableQuantity": available_quantity,  # Available stock
            "especifications": specifications,  # Product specifications
            "skuSpecifications": product.get("skuSpecifications", []),  # SKU-specific details
        }

        # Add the transformed product to the result list
        transformed.append(transformed_product)

    return transformed


if __name__ == "__main__":
    # Load raw product data from the JSON file
    with open("products_data.json", "r", encoding="utf-8") as file:
        products_data = json.load(file)
    
    # Transform the raw product data
    transformed_data = transform_products(products_data)
    
    # Save the transformed data to a new JSON file
    with open("transformed_products_data.json", "w", encoding="utf-8") as outfile:
        json.dump(transformed_data, outfile, ensure_ascii=False, indent=4)
    
    # Output the total number of transformed products
    product_count = len(transformed_data)
    print(f"Transformation completed. {product_count} products have been transformed.")
    print("transformed_products_data.json'")
