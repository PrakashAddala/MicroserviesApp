using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.entities;
using MongoDB.Driver;

namespace Catalog.API.data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> products)
        {
            
            bool existingProducts = products.Find(p 
                => true).Any();
            if (!existingProducts)
            {
                products.InsertManyAsync(GetPreConfiguredProducts());
                

            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name= "Prakash",
                    Category= "Real Estate",
                    Description= "He is the best class provider",
                    ImageFile="jasklf",
                    Price=256.36,
                    Summary="lorem isjfkjasl ld jaskldfjsklad flksdfk kfasljdflkalsj"

                },
                 new Product()
                {
                    Name= "Iphone",
                    Category= "Mobiles",
                    Description= "He is the best class provider",
                    ImageFile="jasklf",
                    Price=256.36,
                    Summary="lorem isjfkjasl ld jaskldfjsklad flksdfk kfasljdflkalsj"

                }
            };
        }
    }
}
