using Catalog.API.data.Interfaces;
using Catalog.API.entities;
using Catalog.API.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            
            return await _context.
                            Products. 
                                Find<Product>(p => true).
                                    ToListAsync<Product>();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _context.
                            Products.
                                 Find<Product>(p => p.Id == id).
                                    FirstOrDefaultAsync<Product>();
        }


        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            //to return multiple responses we need to use filter definiton
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            return await _context.
                            Products.
                                Find<Product>(filter).
                                    ToListAsync<Product>();
        }


        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            //to return multiple responses we need to use filter definiton
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, category);

            return await _context.
                            Products.
                                Find<Product>(filter).
                                    ToListAsync<Product>();
        }

        public async Task CreateProduct(Product product)
        {
            await _context.
                    Products.
                        InsertOneAsync(product);

        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _context.
                                        Products.
                                            ReplaceOneAsync<Product>(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged &&
                    updateResult.ModifiedCount > 0;
                            
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deleteResult = await _context.Products.DeleteOneAsync<Product>(p => p.Id == id);

            return deleteResult.IsAcknowledged &&
                    deleteResult.DeletedCount > 0;

        }
       
    }
}
