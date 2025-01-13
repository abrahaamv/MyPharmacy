import json
import logging
import requests
from time import sleep

# Import the constants we generated earlier
from constants_format import BRANDS, CATEGORIES, SUBCATEGORIES

# Configure logging
logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

API_URL = "http://localhost:5094/productos"  # Adjust to match your actual endpoint
HEADERS = {"Content-Type": "application/json"}

# ---------------------------------------------------------------------------
# Create helper lookup dictionaries for quick brand/category/subcategory ID retrieval
# Example: BRAND_MAP["ENSURE"] -> 3
#          CATEGORY_MAP["OTC"] -> 10
#          SUBCATEGORY_MAP["Sueros"] -> 15
# etc.
# ---------------------------------------------------------------------------
BRAND_MAP = {b["Name"]: b["Id"] for b in BRANDS}
CATEGORY_MAP = {c["Name"]: c["Id"] for c in CATEGORIES}
SUBCATEGORY_MAP = {s["Name"]: s["Id"] for s in SUBCATEGORIES}

# ---------------------------------------------------------------------------
# Helper function to parse the categories in the same way we did before.
# The logic can be as simple or complex as needed, but here's a direct approach:
# ---------------------------------------------------------------------------
def parse_category_info(category_paths):
    """
    Example inputs:
      [" /Farmacia/OTC/ ", "/Farmacia/"]
        -> category = "OTC", subcategory = None

      ["/Farmacia/Estomacales/Sueros/", "/Farmacia/Estomacales/", "/Farmacia/"]
        -> category = "Estomacales", subcategory = "Sueros"
    """
    # Remove trailing spaces and ignore "/Farmacia/" if present
    filtered = [c.strip() for c in category_paths if c.strip() != "/Farmacia/"]
    if not filtered:
        return None, None

    if len(filtered) == 1:
        # e.g. "/Farmacia/OTC/"
        # Remove "/Farmacia/" prefix and trailing slash
        cat_str = filtered[0].replace("/Farmacia/", "").strip("/")
        return cat_str, None

    elif len(filtered) == 2:
        # e.g. ["/Farmacia/Estomacales/Sueros/", "/Farmacia/Estomacales/"]
        first_item = filtered[0].replace("/Farmacia/", "").strip("/")
        second_item = filtered[1].replace("/Farmacia/", "").strip("/")
        # Usually the first one is "Category/Subcategory"
        parts = first_item.split("/")
        if len(parts) == 2:
            category, subcategory = parts[0], parts[1]
            return category, subcategory
        else:
            # fallback
            return second_item, first_item

    return None, None


def map_brand(brand_name):
    """
    Map the brand string to the numeric brand ID, if it exists.
    If not found, we return None (or handle it differently).
    """
    return BRAND_MAP.get(brand_name)


def map_category_and_subcategory(categories):
    """
    Use parse_category_info to separate category from subcategory,
    then map each name to the numeric ID.
    """
    category_name, subcategory_name = parse_category_info(categories)

    category_id = CATEGORY_MAP.get(category_name) if category_name else None
    subcategory_id = SUBCATEGORY_MAP.get(subcategory_name) if subcategory_name else None

    return category_id, subcategory_id


def clean_image_url(url):
    """
    Removes query parameters from image URLs if present.
    e.g. "https://someurl.com/xyz.jpg?v=123" -> "https://someurl.com/xyz.jpg"
    """
    return url.split('?')[0]


def main():
    # Load JSON data (assuming clean_data.json is in the same directory)
    with open("clean_data.json", "r", encoding="utf-8") as file:
        products = json.load(file)

    for product in products:
        try:
            # ----------------------------------------------------------------
            # 1) Map brand
            # ----------------------------------------------------------------
            brand_name = product.get("brand", "").strip()
            brand_id = map_brand(brand_name)
            if not brand_id:
                logging.warning(f"Brand '{brand_name}' not found in constants for product {product['id']}. Skipping.")
                continue

            # ----------------------------------------------------------------
            # 2) Map category and subcategory
            # ----------------------------------------------------------------
            categories = product.get("categories", [])
            category_id, subcategory_id = map_category_and_subcategory(categories)
            if not category_id:
                # If category_id is None, we skip. Or you can decide to allow category=0
                logging.warning(f"No matching category for {categories} (product {product['id']}). Skipping.")
                continue

            # ----------------------------------------------------------------
            # 3) Prepare the request payload
            # ----------------------------------------------------------------
            payload = {
                "ean": product["id"],
                "name": product["Name"],
                "description": product["description"],
                "slug": product["slug"],
                "brandId": brand_id,
                "categoryId": category_id,
                "subcategoryId": subcategory_id,
                "listPrice": product["listPrice"],
                "sellingPrice": product["sellingPrice"],
                "stock": product["availableQuantity"],
                # "imageUrls": [clean_image_url(img["imageUrl"]) for img in product["images"]],
                # Removes any query parameters (e.g., ?v=...) from the image URLs to ensure a cleaner, stable link.
               "imageUrls": [img["imageUrl"] for img in product["images"]],
               "specifications": []
            }

            # Convert the old "especifications" to a simpler key/value structure
            especs = product.get("especifications", [])
            for spec in especs:
                # spec['values'] might be a list with one item, e.g. ["Si"]
                # or multiple items if the data had more. We'll just pick the first if it exists
                val = spec["values"][0] if spec.get("values") else None
                if val:
                    payload["specifications"].append(
                        {
                            "name": spec["name"],
                            "value": val
                        }
                    )

            # ----------------------------------------------------------------
            # 4) POST the product
            # ----------------------------------------------------------------
            response = requests.post(API_URL, headers=HEADERS, json=payload)
            if response.status_code == 201:
                logging.info(f"Product {product['id']} created successfully.")
            else:
                logging.error(
                    f"Failed to create product {product['id']}. "
                    f"Status: {response.status_code}, Response: {response.text}"
                )
                # Decide whether to break/continue on error
                continue

            # Throttle requests if desired
            sleep(0.1)

        except Exception as e:
            logging.exception(f"An error occurred while processing product {product.get('id', 'UNKNOWN')}: {e}")


if __name__ == "__main__":
    main()
