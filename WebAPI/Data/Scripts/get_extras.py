import json

def process_brands(products):
    """Crea el archivo brand.json a partir de las marcas."""
    brands = {}
    brand_id = 1

    for product in products:
        brand_name = product.get("brand")
        if brand_name not in brands:
            brands[brand_name] = {"id": brand_id, "name": brand_name}
            brand_id += 1

    return list(brands.values())

def process_categories(products):
    """Crea el archivo categories.json y subcategories.json."""
    categories = {}
    subcategories = []
    category_id = 1
    subcategory_id = 1

    for product in products:
        for category in product.get("categories", []):
            # Extraer la categoría principal
            if category.startswith("/Farmacia/"):
                main_category = category.split("/")[2] if len(category.split("/")) > 2 else None

                if main_category and main_category not in categories:
                    categories[main_category] = {"id": category_id, "name": main_category}
                    category_id += 1

        # Verificar si hay subcategorías
        if len(product.get("categories", [])) == 3:
            parent_category = product["categories"][1].split("/")[2]
            subcategory = product["categories"][0].split("/")[-2]

            # Encontrar el id de la categoría padre
            parent_id = next(
                (cat["id"] for cat in categories.values() if cat["name"] == parent_category), None
            )

            if parent_id and not any(sc["name"] == subcategory for sc in subcategories):
                subcategories.append(
                    {"id": subcategory_id, "categoryId": parent_id, "name": subcategory}
                )
                subcategory_id += 1

    return list(categories.values()), subcategories

def save_to_json(data, filename):
    """Guarda los datos en un archivo JSON."""
    with open(filename, "w", encoding="utf-8") as file:
        json.dump(data, file, ensure_ascii=False, indent=4)

def main():
    # Cargar el archivo products.json
    with open("products.json", "r", encoding="utf-8") as file:
        products = json.load(file)

    # Procesar marcas
    brands = process_brands(products)
    save_to_json(brands, "brand.json")
    print(f"Archivo brand.json creado con {len(brands)} marcas.")

    # Procesar categorías y subcategorías
    categories, subcategories = process_categories(products)
    save_to_json(categories, "categories.json")
    save_to_json(subcategories, "subcategories.json")
    print(f"Archivo categories.json creado con {len(categories)} categorías.")
    print(f"Archivo subcategories.json creado con {len(subcategories)} subcategorías.")

if __name__ == "__main__":
    main()
