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

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}
