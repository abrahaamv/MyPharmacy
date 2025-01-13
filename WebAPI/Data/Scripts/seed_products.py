import json
import logging
import requests
from time import sleep

# 1) Import your dictionaries from constants_format
from constants_format import BRANDS, CATEGORIES, SUBCATEGORIES

# 2) Build quick name->ID maps
BRAND_MAP = {b["Name"]: b["Id"] for b in BRANDS}
CATEGORY_MAP = {c["Name"]: c["Id"] for c in CATEGORIES}
SUBCATEGORY_MAP = {s["Name"]: s["Id"] for s in SUBCATEGORIES}

# 3) Same parse_category_info logic you used in the dictionary script
def parse_category_info(categories_list):
    """
    If we have an array like ["/Farmacia/OTC/", "/Farmacia/"],
      => category="OTC", subcategory=None
    If we have ["/Farmacia/Estomacales/Sueros/", "/Farmacia/Estomacales/", "/Farmacia/"],
      => category="Estomacales", subcategory="Sueros"
    """
    filtered = [cat for cat in categories_list if cat != "/Farmacia/"]
    category = None
    subcategory = None

    if len(filtered) == 1:
        # e.g. "/Farmacia/OTC/" => "OTC"
        item = filtered[0].replace("/Farmacia/", "").strip("/")
        category = item if item else None

    elif len(filtered) == 2:
        # e.g. ["/Farmacia/Estomacales/Sueros/", "/Farmacia/Estomacales/"]
        first_item = filtered[0].replace("/Farmacia/", "").strip("/")
        second_item = filtered[1].replace("/Farmacia/", "").strip("/")
        parts = first_item.split("/")
        if len(parts) == 2:
            category, subcategory = parts[0], parts[1]
        else:
            category, subcategory = second_item, first_item

    return category, subcategory

API_URL = "http://localhost:5094/productos"  # Adjust if needed
HEADERS = {"Content-Type": "application/json"}

logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

def build_and_post_product(product):
    """
    Given a single product dict from clean_data.json, parse brand/category/subcategory,
    build the JSON payload, and POST to the API.
    """
    brand_name = product.get("brand", "").strip()
    brand_id = BRAND_MAP.get(brand_name)
    if not brand_id:
        logging.warning(f"[SKIP] Product {product['id']}: unknown brand '{brand_name}'")
        return

    # Parse category & subcategory using your dictionary logic
    cat_list = product.get("categories", [])
    category_name, subcategory_name = parse_category_info(cat_list)

    # DEBUG: show exactly what's being parsed
    logging.debug(
        f"[DEBUG] Product {product['id']} => category='{category_name}', subcategory='{subcategory_name}', "
        f"rawCategories={cat_list}"
    )

    if not category_name:
        logging.warning(f"[SKIP] Product {product['id']}: no recognized category. raw={cat_list}")
        return

    category_id = CATEGORY_MAP.get(category_name)
    if not category_id:
        logging.warning(f"[SKIP] Product {product['id']}: unknown category '{category_name}'")
        return

    subcategory_id = None
    if subcategory_name:
        sub_id = SUBCATEGORY_MAP.get(subcategory_name)
        if not sub_id:
            logging.warning(f"[SKIP] Product {product['id']}: unknown subcategory '{subcategory_name}'")
            return
        subcategory_id = sub_id

    # Build the payload
    payload = {
        "ean": product["id"],
        "name": product["Name"],
        "description": product["description"],
        "slug": product["slug"],
        "brandId": brand_id,
        "categoryId": category_id,
        "subCategoryId": subcategory_id,  # None => becomes null in JSON
        "listPrice": product["listPrice"],
        "sellingPrice": product["sellingPrice"],
        "stock": product["availableQuantity"],
        "imageUrls": [img["imageUrl"] for img in product["images"]],
        "specifications": []
    }

    # Convert the old "especifications" array to key-value
    for spec in product.get("especifications", []):
        vals = spec.get("values", [])
        if vals:
            payload["specifications"].append({"name": spec["name"], "value": vals[0]})

    # POST to the API
    try:
        response = requests.post(API_URL, headers=HEADERS, json=payload)
        if response.status_code == 201:
            logging.info(f"[OK] Product {product['id']} posted. subCategoryId={subcategory_id}")
        else:
            logging.error(
                f"[FAIL] Product {product['id']} => {response.status_code}: {response.text}"
            )
    except Exception as e:
        logging.exception(f"[ERROR] Product {product['id']}: {e}")

    sleep(0.1)

def main():
    # Load the JSON data
    with open("clean_data.json", "r", encoding="utf-8") as f:
        products = json.load(f)

    for product in products:
        build_and_post_product(product)

if __name__ == "__main__":
    main()
