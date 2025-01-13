import json

def parse_category_info(categories_list):
    """
    The same logic from your dictionary script.
    Given a product's 'categories' field, determine (category, subcategory).
    We ignore the final '/Farmacia/' element if it exists.

    Examples:
      1) ["/Farmacia/OTC/", "/Farmacia/"]
         => Category: "OTC", Subcategory: None

      2) ["/Farmacia/Estomacales/Sueros/", "/Farmacia/Estomacales/", "/Farmacia/"]
         => Category: "Estomacales", Subcategory: "Sueros"
    """
    filtered = [cat for cat in categories_list if cat != "/Farmacia/"]
    category = None
    subcategory = None

    if len(filtered) == 1:
        item = filtered[0].replace("/Farmacia/", "").strip("/")
        category = item if item else None
    elif len(filtered) == 2:
        first_item = filtered[0].replace("/Farmacia/", "").strip("/")
        second_item = filtered[1].replace("/Farmacia/", "").strip("/")
        parts = first_item.split("/")
        if len(parts) == 2:
            category = parts[0]
            subcategory = parts[1]
        else:
            category = second_item
            subcategory = first_item

    return category, subcategory

def main():
    # Load the clean_data.json file
    with open("clean_data.json", "r", encoding="utf-8") as f:
        products = json.load(f)

    # Dictionary: subcategory -> set of categories
    subcat_to_cats = {}

    for product in products:
        categories_list = product.get("categories", [])
        cat, subcat = parse_category_info(categories_list)
        
        if subcat:
            if subcat not in subcat_to_cats:
                subcat_to_cats[subcat] = set()
            if cat:
                subcat_to_cats[subcat].add(cat)

    # Check if any subcategory is linked to more than one category
    multiple_cats_found = False
    for subcat, cat_set in subcat_to_cats.items():
        if len(cat_set) > 1:
            multiple_cats_found = True
            print(f"Subcategory '{subcat}' belongs to multiple categories: {cat_set}")

    if not multiple_cats_found:
        print("No subcategory is assigned to multiple categories based on current data.")

if __name__ == "__main__":
    main()

