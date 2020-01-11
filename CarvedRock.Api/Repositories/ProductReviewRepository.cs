using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Repositories
{
    public class ProductReviewRepository
    {
        public ProductReviewRepository(CarvedRockDbContext context) => Context = context;
        CarvedRockDbContext Context { get; }

        public async Task<IEnumerable<ProductReview>> GetForProductAsync(int productId)
            => await Context.ProductReviews.Where(pr => pr.ProductId == productId).ToListAsync();

        public async Task<ILookup<int, ProductReview>> GetForProductsAsync(IEnumerable<int> productIds) =>
            (await Context.ProductReviews
                .Where(pr => productIds.Contains(pr.ProductId))
                .ToListAsync())
                .ToLookup(r => r.ProductId);

        public async Task<ProductReview> AddReviewAsync(ProductReview review)
        {
            Context.ProductReviews.Add(review);
            await Context.SaveChangesAsync();
            return review;
        }
    }
}
