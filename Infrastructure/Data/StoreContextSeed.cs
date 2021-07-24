using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try{
                if(!context.ProductBrands.Any()){
                    var brandsData = File.ReadAllText("../Infrastructure/Data/Seed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    await context.AddRangeAsync(brands);
                    await context.SaveChangesAsync();
                }

                if(!context.ProductTypes.Any()){
                    var typesData = File.ReadAllText("../Infrastructure/Data/Seed/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    await context.AddRangeAsync(types);
                    await context.SaveChangesAsync();
                }

                if(!context.Products.Any()){
                    var productsData = File.ReadAllText("../Infrastructure/Data/Seed/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    await context.AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }


            }catch(Exception ex){
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, "An error occurred during data seeding");
            }
        }
    }
}