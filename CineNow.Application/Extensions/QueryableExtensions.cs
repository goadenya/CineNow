using CineNow.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using CineNow.Domain.Common.Constants;

namespace CineNow.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize, string orderOption, CancellationToken cancellationToken) where T : class
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;

            pageSize = pageSize == 0 ? 10 : pageSize;

            int count = await source.CountAsync();

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;

            List<T> items = await source.OrderBy(OrderOption.Movie.GetOrderOption(orderOption)).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return PaginatedResult<T>.Create(items, count, pageNumber, pageSize);
        }
    }

    public static class EnumExtensions
    {
        public static string GetNameAsString<T>(this Enum e)
        {
            return e.ToString();
        }
    }
}
