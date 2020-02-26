using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore2.Models
{
    public class EfProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public EfProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products;
    }
}
