using PolimericosInventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PolimericosInventoryAPI.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (await context.Products.AnyAsync()) return;

            var categories = new Dictionary<string, Category>();

            string[] categoryNames = new[]
            {
                "METALIZADO", "FOSFORESCENTE", "FLUORESCENTES", "METAL FLAKE", "HOLOGRAFICOS",
                "TERMOCROMICOS", "TERCIOPELO", "PHILIPS FLAKE", "CAMALEONES", "CANDY", "PERLAS", "LÍQUIDOS"
            };

            foreach (var name in categoryNames)
            {
                var cat = new Category { Name = name };
                categories[name] = cat;
                context.Categories.Add(cat);
            }

            var products = new List<Product>
            {
                new Product { Name = "Oro", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 11.70m, Category = categories["METALIZADO"] },
                new Product { Name = "Esmeralda", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 47m, Category = categories["METALIZADO"] },
                new Product { Name = "Blanco", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 10m, Category = categories["METALIZADO"] },
                new Product { Name = "Rojo", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 46m, Category = categories["METALIZADO"] },
                new Product { Name = "Azul", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 10m, Category = categories["METALIZADO"] },
                new Product { Name = "Negro", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 5m, Category = categories["METALIZADO"] },

                new Product { Name = "Catalizador hs 2 a 1", ProductType = ProductType.Liquid, Unit = "parts", Note = "Menos de la mitad tarro de 1/8", Category = categories["LÍQUIDOS"] },
                new Product { Name = "Catalizador?", ProductType = ProductType.Liquid, Unit = "parts", Note = "1/32 completo", Category = categories["LÍQUIDOS"] },
                new Product { Name = "Activador P.V.A", ProductType = ProductType.Liquid, Unit = "parts", Note = "Agotado", Category = categories["LÍQUIDOS"] },
                new Product { Name = "Barniz hs 2 a 1", ProductType = ProductType.Liquid, Unit = "parts", Note = "Menos de la mitad tarro de 1/4", Category = categories["LÍQUIDOS"] },
                new Product { Name = "Base negra", ProductType = ProductType.Base, Unit = "liters", Note = "Galón poco más de la mitad", Category = categories["LÍQUIDOS"] },
                new Product { Name = "Base poliester", ProductType = ProductType.Base, Unit = "liters", Note = "Galón casi completo", Category = categories["LÍQUIDOS"] },
                new Product { Name = "Base aluminio fino", ProductType = ProductType.Base, Unit = "liters", Note = "Galón completo", Category = categories["LÍQUIDOS"] },
                new Product { Name = "Easy chrome", ProductType = ProductType.Liquid, Unit = "parts", Note = "Tarro 1/8 más de la mitad", Category = categories["LÍQUIDOS"] },
            };
            // Add products to the context
            products.AddRange(new[]
            {
                new Product { Name = "Verde", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 30m, Category = categories["FOSFORESCENTE"] },
                new Product { Name = "Azul", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 23m, Category = categories["FOSFORESCENTE"] }
            });

            products.AddRange(new[]
            {
                new Product { Name = "Naranja", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 10m, Category = categories["FLUORESCENTES"] },
                new Product { Name = "Morado", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 25m, Category = categories["FLUORESCENTES"] },
                new Product { Name = "Rosado", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 20m, Category = categories["FLUORESCENTES"] },
                new Product { Name = "Verde", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 5m, Category = categories["FLUORESCENTES"] },
                new Product { Name = "Magenta", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 15m, Category = categories["FLUORESCENTES"] },
                new Product { Name = "Azul", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 30m, Category = categories["FLUORESCENTES"] }
            });

            products.AddRange(new[]
            {
                new Product { Name = "Rojo", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 30m, Category = categories["METAL FLAKE"] },
                new Product { Name = "Dorado", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 20m, Category = categories["METAL FLAKE"] },
                new Product { Name = "Verde oscuro", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 30m, Category = categories["METAL FLAKE"] },
                new Product { Name = "Verde manzana", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 35m, Category = categories["METAL FLAKE"] },
                new Product { Name = "Rosa", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 37m, Category = categories["METAL FLAKE"] },
                new Product { Name = "Violeta", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 40m, Category = categories["METAL FLAKE"] },
                new Product { Name = "Azul", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 37m, Category = categories["METAL FLAKE"] },
                new Product { Name = "Plata", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 30m, Category = categories["METAL FLAKE"] }
            });

            products.AddRange(new[]
            {
                new Product { Name = "Plata 0.008", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 105m, Category = categories["HOLOGRAFICOS"] },
                new Product { Name = "Plata 0.004", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 122m, Category = categories["HOLOGRAFICOS"] },
                new Product { Name = "Dorado", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 112m, Category = categories["HOLOGRAFICOS"] }
            });

            products.AddRange(new[]
            {
                new Product { Name = "Plateado", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 85m, Category = categories["TERCIOPELO"] }
            });

            products.AddRange(new[]
            {
                new Product { Name = "Plata 0.035", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 100m, Category = categories["PHILIPS FLAKE"] }
            });

            products.AddRange(new[]
            {
                new Product { Name = "Rosa dorado 3820", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 25m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 7230", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 33m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 7220", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 2m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 9470", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 2m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 9430", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 3m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 8460", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 15m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 9440", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 42m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 9410", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 18m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 8440", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 10m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 7210", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 26m, Category = categories["CAMALEONES"] },
                new Product { Name = "Camaleon 3970", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 20m, Category = categories["CAMALEONES"] }
            });

            products.AddRange(new[]
            {
                new Product { Name = "Azul rey", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 40m, Category = categories["CANDY"] },
                new Product { Name = "Rojo", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 55m, Category = categories["CANDY"] },
                new Product { Name = "Azul oscuro", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 25m, Category = categories["CANDY"] },
                new Product { Name = "Amarillo", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 33m, Category = categories["CANDY"] },
                new Product { Name = "Amarillo 2090", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 25m, Category = categories["CANDY"] },
                new Product { Name = "Verde", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 28m, Category = categories["CANDY"] },
                new Product { Name = "Negro", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 30m, Category = categories["CANDY"] }
            });

            products.AddRange(new[]
            {
                new Product { Name = "Blanco", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 55m, Category = categories["PERLAS"] },
                new Product { Name = "Violeta", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 55m, Category = categories["PERLAS"] },
                new Product { Name = "Roja", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 60m, Category = categories["PERLAS"] },
                new Product { Name = "Verde", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 55m, Category = categories["PERLAS"] },
                new Product { Name = "Azul", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 70m, Category = categories["PERLAS"] },
                new Product { Name = "Fantasma p23F", ProductType = ProductType.Pigment, Unit = "grams", QuantityInStock = 5m, Category = categories["PERLAS"] }
            });



            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
        public static async Task ResetAndSeedAsync(AppDbContext context)
        {
            context.Products.RemoveRange(context.Products);
            context.Categories.RemoveRange(context.Categories);
            await context.SaveChangesAsync();

            await SeedAsync(context);
        }

    }
}
