using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Data.Utilities.EntityFramework
{
    public class EfPaginatedList<T> : PaginatedList<T>
    {
        public EfPaginatedList(List<T> items, int count, int pageIndex, int pageSize)
            : base(items, count, pageIndex, pageSize)
        {

        }

        public static async Task<EfPaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return new EfPaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
