# This script retrieves product data from the Walmart Guatemala API by sending HTTP requests with specific parameters.
# It supports pagination, handles large datasets, and saves the extracted data to a JSON file for further use or analysis.


import requests
import logging
import json
from urllib.parse import urlencode

# Logging configuration
# Configures the logging format and level to capture information and errors during execution.
logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

# Base URL for the API
# This is the endpoint used to fetch data from the Walmart website.
BASE_URL = "https://www.walmart.com.gt/_v/segment/graphql/v1"

# Request parameters
# Default parameters required by the API for all requests.
BASE_PARAMS = {
    "workspace": "master",
    "maxAge": "short",
    "appsEtag": "remove",
    "domain": "store",
    "locale": "es-GT",
    "__bindingId": "0fa8eb69-6107-4653-a94d-91e86c3ea120",
    "operationName": "productSearchV3",
    "extensions": json.dumps({
        "persistedQuery": {
            "version": 1,
            "sha256Hash": "9177ba6f883473505dc99fcf2b679a6e270af6320a157f0798b92efeab98d5d3",
            "sender": "vtex.store-resources@0.x",
            "provider": "vtex.search-graphql@0.x",
        }
    }),
}

# Variable parameters
# These parameters vary depending on the search query or pagination needs.
BASE_VARIABLES = {
    "hideUnavailableItems": False,
    "skusFilter": "ALL",
    "simulationBehavior": "default",
    "query": "farmacia",  # Search term or category
    "orderBy": "OrderByScoreDESC",  # Sorting criteria
    "from": 0,  # Start index for pagination
    "to": 20,  # End index for pagination
    "selectedFacets": [{"key": "c", "value": "farmacia"}],  # Filters applied to the query
}

def get_total_products():
    """
    Fetch the total number of products available for the given query.
    This is determined by requesting only the first product and checking the total count.
    """
    params = BASE_PARAMS.copy()
    variables = BASE_VARIABLES.copy()
    variables["from"] = 0
    variables["to"] = 1  # Fetch a single product to retrieve metadata
    params["variables"] = json.dumps(variables)

    url = f"{BASE_URL}?{urlencode(params)}"
    try:
        response = requests.get(url)
        response.raise_for_status()
        data = response.json()
        return data.get("data", {}).get("productSearch", {}).get("recordsFiltered", 0)
    except Exception as e:
        logging.error(f"Error obtaining total products: {e}")
        return 0

def fetch_products(total_products, step=20):
    """
    Fetch all products using pagination.
    Retrieves products in chunks (pages) to handle large datasets efficiently.
    """
    all_products = []
    from_index = 0

    while from_index < total_products:
        # Update pagination range
        variables = BASE_VARIABLES.copy()
        variables["from"] = from_index
        variables["to"] = min(from_index + step, total_products)

        # Add variables to request parameters
        params = BASE_PARAMS.copy()
        params["variables"] = json.dumps(variables)

        # Build the request URL
        url = f"{BASE_URL}?{urlencode(params)}"
        logging.info(f"Fetching products from {from_index} to {variables['to']}...")

        try:
            response = requests.get(url)
            response.raise_for_status()
            data = response.json()

            # Extract products from response
            products = data.get("data", {}).get("productSearch", {}).get("products", [])
            all_products.extend(products)
            logging.info(f"Retrieved {len(products)} products. Total so far: {len(all_products)}.")

        except Exception as e:
            logging.error(f"Error fetching products from range {from_index} to {variables['to']}: {e}")
            break

        # Increment the pagination index
        from_index += step

    return all_products

def save_to_json(products, filename="raw_data.json"):
    """
    Save the extracted products to a JSON file.
    """
    with open(filename, "w", encoding="utf-8") as file:
        json.dump(products, file, ensure_ascii=False, indent=4)
    logging.info(f"Products saved to {filename}")


# --------------------------------------------------------------------------
# This script processes and transforms raw product data obtained from the Walmart Guatemala API.
# It extracts relevant fields, formats the data, and prepares it to be used in our API.
# The transformed data is then saved to a new JSON file for further use or integration.

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
# --------------------------------------------------------------------------


if __name__ == "__main__":
    # Entry point for the script
    logging.info("Starting product extraction process...")
    total_products = get_total_products()
    logging.info(f"Total products available: {total_products}")

    if total_products > 0:
        products = fetch_products(total_products, step=50)  # Adjust the step size as needed
        save_to_json(products, filename="raw_data.json")
        logging.info(f"Process completed. Total products extracted: {len(products)}")
    else:
        logging.warning("No products found to extract.")
    
    # Now proceed with the transformation step (reading from raw_data.json and saving to clean_data.json)
    logging.info("Starting transformation process...")
    try:
        with open("raw_data.json", "r", encoding="utf-8") as file:
            products_data = json.load(file)

        transformed_data = transform_products(products_data)

        with open("clean_data.json", "w", encoding="utf-8") as outfile:
            json.dump(transformed_data, outfile, ensure_ascii=False, indent=4)

        product_count = len(transformed_data)
        logging.info(f"Transformation completed. {product_count} products have been transformed.")
        logging.info("clean_data.json has been created.")
    except Exception as e:
        logging.error(f"Error transforming products: {e}")
