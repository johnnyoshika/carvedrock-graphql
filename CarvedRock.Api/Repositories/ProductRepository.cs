using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Repositories
{
    public class ProductRepository
    {
        public ProductRepository(CarvedRockDbContext context) => Context = context;
        CarvedRockDbContext Context { get; }

        public async Task<IEnumerable<Product>> GetAllAsync() => await Context.Products.ToListAsync();

        public async Task<Product> GetOneAsync(int id) => await Context.Products.SingleOrDefaultAsync(p => p.Id == id);
    }
}
