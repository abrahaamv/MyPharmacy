import json

def load_clean_data(filename="clean_data.json"):
    """
    Reads the JSON file containing the clean product data.
    Returns a list of product dictionaries.
    """
    with open(filename, "r", encoding="utf-8") as f:
        return json.load(f)

def parse_category_info(categories_list):
    """
    Given a product's 'categories' field, determine:
    - category (if available)
    - subcategory (if available)
    
    We ignore the final '/Farmacia/' element if it exists.
    
    Examples:
      1) ["/Farmacia/OTC/", "/Farmacia/"]
         => Category: "OTC", no Subcategory

      2) ["/Farmacia/Estomacales/Sueros/", "/Farmacia/Estomacales/", "/Farmacia/"]
         => Category: "Estomacales", Subcategory: "Sueros"
    """
    # Filter out "/Farmacia/" if it exists at all
    filtered = [cat for cat in categories_list if cat != "/Farmacia/"]
    category = None
    subcategory = None

    # If we have 1 item left, it might be "/Farmacia/OTC/" => category="OTC"
    if len(filtered) == 1:
        # e.g. "/Farmacia/OTC/" => "OTC"
        item = filtered[0].replace("/Farmacia/", "").strip("/")
        category = item if item else None

    # If we have 2 items left, likely something like:
    #   ["/Farmacia/Estomacales/Sueros/", "/Farmacia/Estomacales/"]
    elif len(filtered) == 2:
        # The first might be "Estomacales/Sueros" and the second "Estomacales"
        first_item = filtered[0].replace("/Farmacia/", "").strip("/")
        second_item = filtered[1].replace("/Farmacia/", "").strip("/")

        # We can attempt to split the first_item by "/"
        parts = first_item.split("/")
        if len(parts) == 2:
            category = parts[0]  # e.g. "Estomacales"
            subcategory = parts[1]  # e.g. "Sueros"
        else:
            # If for some reason it doesn't split into 2 parts, fallback:
            # Possibly the second item is the simpler one
            category = second_item
            subcategory = first_item

    return category, subcategory

def accumulate_ids(items):
    """
    Given an iterable of item names, assign each a unique ID in order of appearance.
    Returns a list of {"Id": int, "Name": str} in the order discovered.
    """
    seen = {}
    assigned_list = []
    current_id = 1

    for element in items:
        if element and element not in seen:
            seen[element] = current_id
            assigned_list.append({"Id": current_id, "Name": element})
            current_id += 1

    return assigned_list

def main():
    products = load_clean_data("clean_data.json")

    brand_list = []
    category_list = []
    subcategory_list = []

    seen_brands = set()
    seen_categories = set()
    seen_subcategories = set()

    # This map will hold subcategory_name -> category_name
    # so that later we can know which category a subcategory belongs to.
    subcat_to_cat = {}

    for product in products:
        # 1) Brand
        brand = product.get("brand", "").strip()
        if brand and brand not in seen_brands:
            seen_brands.add(brand)
            brand_list.append(brand)

        # 2) Categories -> parse out category and subcategory
        categories = product.get("categories", [])
        c, sc = parse_category_info(categories)

        if c and c not in seen_categories:
            seen_categories.add(c)
            category_list.append(c)

        if sc and sc not in seen_subcategories:
            seen_subcategories.add(sc)
            subcategory_list.append(sc)

        # We also record subcategory -> category
        if sc and c:
            # If not already mapped, set it
            # (If it appears again with a different category, this script doesn't handle that scenario)
            if sc not in subcat_to_cat:
                subcat_to_cat[sc] = c

    # Now assign IDs in order of appearance
    brand_objects = accumulate_ids(brand_list)
    category_objects = accumulate_ids(category_list)
    subcategory_objects = accumulate_ids(subcategory_list)

    # Build a quick lookup dict for category name -> category ID
    category_name_to_id = {cat_obj["Name"]: cat_obj["Id"] for cat_obj in category_objects}

    # 1) Write them in "constants_format.py"
    # Python style: BRANDS = [{"Id": 1, "Name": ...}, ...]
    constants_lines = []
    constants_lines.append("# Constants\n\n")

    # BRANDS
    constants_lines.append("BRANDS = [\n")
    for b in brand_objects:
        constants_lines.append(f'    {{"Id": {b["Id"]}, "Name": "{b["Name"]}"}},\n')
    constants_lines.append("]\n\n")

    # CATEGORIES
    constants_lines.append("CATEGORIES = [\n")
    for cobj in category_objects:
        constants_lines.append(f'    {{"Id": {cobj["Id"]}, "Name": "{cobj["Name"]}"}},\n')
    constants_lines.append("]\n\n")

    # SUBCATEGORIES
    constants_lines.append("SUBCATEGORIES = [\n")
    for sobj in subcategory_objects:
        constants_lines.append(f'    {{"Id": {sobj["Id"]}, "Name": "{sobj["Name"]}"}},\n')
    constants_lines.append("]\n")

    with open("constants_format.py", "w", encoding="utf-8") as f:
        f.write("".join(constants_lines))

    # 2) Write them in "new_format.txt" (C# style)
    # We'll create separate sections for brands, categories, subcategories
    new_format_lines = []

    # --- BRANDS ---
    new_format_lines.append("BRANDS:\n\n")
    for b in brand_objects:
        new_format_lines.append(
            "new\n{\n"
            f"    Id = {b['Id']},\n"
            f"    Name = \"{b['Name']}\"\n"
            "},\n"
        )

    # --- CATEGORIES ---
    new_format_lines.append("\nCATEGORIES:\n\n")
    for cobj in category_objects:
        new_format_lines.append(
            "new\n{\n"
            f"    Id = {cobj['Id']},\n"
            f"    Name = \"{cobj['Name']}\"\n"
            "},\n"
        )

    # --- SUBCATEGORIES ---
    new_format_lines.append("\nSUBCATEGORIES:\n\n")
    for sobj in subcategory_objects:
        subcat_id = sobj["Id"]
        subcat_name = sobj["Name"]
        # Figure out which category this subcat belongs to
        # and get the corresponding category ID (default to 0 if unknown).
        cat_name = subcat_to_cat.get(subcat_name)
        cat_id = category_name_to_id.get(cat_name, 0) if cat_name else 0

        new_format_lines.append(
            "new\n{\n"
            f"    Id = {subcat_id},\n"
            f"    CategoryId = {cat_id},\n"
            f"    Name = \"{subcat_name}\"\n"
            "},\n"
        )

    with open("new_format.txt", "w", encoding="utf-8") as f:
        f.write("".join(new_format_lines))

    print("Generation completed successfully!")
    print(" - 'constants_format.py' created (Python-style constants).")
    print(" - 'new_format.txt' created (C#-style output).")

if __name__ == "__main__":
    main()
