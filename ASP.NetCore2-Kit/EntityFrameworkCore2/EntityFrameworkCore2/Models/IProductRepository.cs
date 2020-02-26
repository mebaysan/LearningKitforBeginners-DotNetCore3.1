using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore2.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; } // sadece okunabilir (set edilemesin) istiyoruz.
        // Not Interface olduğu için erişim bildirgeci olmayacak
    }
}
