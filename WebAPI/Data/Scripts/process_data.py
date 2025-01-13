import json
import logging
import requests
from time import sleep

# 1) Import the constants we generated earlier
from constants_format import BRANDS, CATEGORIES, SUBCATEGORIES

# 2) We REBUILD the same parse_category_info logic from your dictionary script
def parse_category_info(categories_list):
    """
    Given a product's 'categories' field, determines:
    - category (if available)
    - subcategory (if available)

    The same logic you used when generating the dictionaries. 
    We ignore the final '/Farmacia/' element if present.

    Examples:
        ["/Farmacia/OTC/", "/Farmacia/"] 
            => category="OTC", subcategory=None
        ["/Farmacia/Estomacales/Sueros/", "/Farmacia/Estomacales/", "/Farmacia/"]
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
            category = parts[0]
            subcategory = parts[1]
        else:
            # fallback if it didn't split neatly
            category = second_item
            subcategory = first_item

    return category, subcategory


# 3) Build a quick map for brand/category/subcategory (Name -> Id)
BRAND_MAP = {b["Name"]: b["Id"] for b in BRANDS}
CATEGORY_MAP = {c["Name"]: c["Id"] for c in CATEGORIES}
SUBCATEGORY_MAP = {s["Name"]: s["Id"] for s in SUBCATEGORIES}


# 4) Rebuild subcat_to_cat to match your dictionary logic
#    For each SUBCATEGORY entry in SUBCATEGORIES, we rely on the data your dictionary script generated:
#    - That script used subcat_to_cat[subcategory_name] = category_name
#    - But we only stored "CategoryId" in the final output. So let's do a best guess:
#    We'll parse "CategoryId" from your new_format or we can look up the subcategory "Name" in SUBCATEGORIES 
#    and see if we also recorded which category it belongs to. 
#    If we don't have that stored, we can re-derive it at runtime by scanning the data from your script.
#
#    The easiest approach is to replicate the logic from the dictionary script:
#    subcat_to_cat[subcat["Name"]] = (some category name) 
#    But we only have a "CategoryId" in the final new_format. We need a "Category Name" for the cross-check.
#
#    If you do *not* have a direct way to see which category a subcategory belongs to from the constants alone,
#    we can store a partial map that we rebuild from new_format, or keep it in memory when we originally built
#    constants_format. For demonstration, let's show how we'd rebuild from new_format if it had lines like:
#    new
#    {
#        Id = 10,
#        CategoryId = 2,
#        Name = "Sueros"
#    },
#    This indicates "Sueros" is subcategory ID=10 under category ID=2. We then invert the category ID=2
#    to category name from the map, so subcat_to_cat["Sueros"] = "Estomacales".
#
#    For now, let's do a simple approach: If subcategory "X" is listed, we look up "CategoryId" in new_format,
#    then we invert that ID to the category name. We'll skip this if not available. 
#
#    Because we don't have your new_format with lines here, let's pretend we do the same logic as your
#    dictionary script: "subcat_to_cat[subcat_name] = category_name if found"
#
#    If you want to ensure subcategories belong to the correct category, you must confirm the "subcat_to_cat"
#    was created the same way you did in your dictionary script. 
#
#    For demonstration, let's rebuild subcat_to_cat on the fly from the final dictionary script approach:
#    We'll parse the 'new_format.txt' lines or keep a known dictionary. 
#    But let's keep it simpler: we'll only cross-check if subcategory -> category_name is consistent
#    with the categories array in each product. That means we do the parsing *again* for each product
#    and see if it matches. That is effectively done in parse_category_and_subcategory.
#
#    We'll do the safer approach: parse the product's category & subcategory, see if subcategory->category
#    is consistent with the "dictionary script" logic: 
#    "If sc in subcat_to_cat, subcat_to_cat[sc] == c"
#
#    So let's build subcat_to_cat the same way your dictionary script does (re-deriving from the entire clean_data).
#

def rebuild_subcat_to_cat(clean_data_path="clean_data.json"):
    """
    Rebuilds the subcat_to_cat dictionary from scratch, 
    just like your dictionary script did, so we can cross-check.
    """
    with open(clean_data_path, "r", encoding="utf-8") as f:
        products = json.load(f)

    subcat_to_cat_map = {}
    for product in products:
        categories = product.get("categories", [])
        c, sc = parse_category_info(categories)
        if c and sc:
            # If subcat not already mapped, set it
            if sc not in subcat_to_cat_map:
                subcat_to_cat_map[sc] = c
    return subcat_to_cat_map


# 5) Rebuild subcat_to_cat from the same "clean_data.json" (or do it from your new_format):
subcat_to_cat = rebuild_subcat_to_cat("clean_data.json")

# Now we have subcat_to_cat, e.g. { "Sueros": "Estomacales", "Dolor": "OTC", ... }

logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')

API_URL = "http://localhost:5094/productos"  # Adjust if needed
HEADERS = {"Content-Type": "application/json"}


def main():
    # 6) Load the same clean_data to seed from
    with open("clean_data.json", "r", encoding="utf-8") as file:
        products = json.load(file)

    for product in products:
        try:
            # ----------------------------------------------------------------
            # A) Parse brand
            # ----------------------------------------------------------------
            brand_name = product.get("brand", "").strip()
            brand_id = BRAND_MAP.get(brand_name)
            if not brand_id:
                logging.warning(
                    f"[SKIP] Brand '{brand_name}' not found in constants for product {product['id']}."
                )
                continue

            # ----------------------------------------------------------------
            # B) Parse categories from product's structure
            # ----------------------------------------------------------------
            categories = product.get("categories", [])
            category_name, subcategory_name = parse_category_info(categories)

            # If there's no recognized category name, skip
            if not category_name:
                logging.warning(
                    f"[SKIP] No recognized category from {categories} for product {product['id']}."
                )
                continue

            # Map category name to ID
            category_id = CATEGORY_MAP.get(category_name)
            if not category_id:
                logging.warning(
                    f"[SKIP] Category '{category_name}' not found in constants for product {product['id']}."
                )
                continue

            subcategory_id = None
            if subcategory_name:
                subcategory_id = SUBCATEGORY_MAP.get(subcategory_name)
                if not subcategory_id:
                    logging.warning(
                        f"[SKIP] Subcategory '{subcategory_name}' not found in constants for product {product['id']}."
                    )
                    continue

            # ----------------------------------------------------------------
            # C) Cross-check the subcat_to_cat relationship
            # ----------------------------------------------------------------
            # If subcategory exists, we look up in subcat_to_cat to confirm it belongs to the same category
            if subcategory_name and subcategory_name in subcat_to_cat:
                expected_category = subcat_to_cat[subcategory_name]
                if expected_category != category_name:
                    logging.error(
                        f"[SKIP] Mismatch: subcategory '{subcategory_name}' belongs to '{expected_category}', "
                        f"but we parsed category '{category_name}' for product {product['id']}."
                    )
                    continue

            # ----------------------------------------------------------------
            # D) Build the request payload
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
                "imageUrls": [img["imageUrl"] for img in product["images"]],
                "specifications": []
            }

            # Convert the old "especifications" to simpler key/value pairs
            especs = product.get("especifications", [])
            for spec in especs:
                val = spec["values"][0] if spec.get("values") else None
                if val:
                    payload["specifications"].append({"name": spec["name"], "value": val})

            # ----------------------------------------------------------------
            # E) POST the product
            # ----------------------------------------------------------------
            response = requests.post(API_URL, headers=HEADERS, json=payload)
            if response.status_code == 201:
                logging.info(f"[OK] Product {product['id']} created successfully.")
            else:
                logging.error(
                    f"[FAIL] Product {product['id']} not created. Status: {response.status_code}, Response: {response.text}"
                )
                # Decide if you want to continue or break
                continue

            # Throttle requests slightly
            sleep(0.1)

        except Exception as e:
            logging.exception(
                f"[ERROR] An error occurred while processing product {product.get('id', 'UNKNOWN')}: {e}"
            )


if __name__ == "__main__":
    main()
