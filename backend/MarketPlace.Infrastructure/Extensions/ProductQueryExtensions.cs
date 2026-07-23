using MarketPlace.Domain.Collections;
using MarketPlace.Application.Query.Sorting;
namespace MarketPlace.Infrastructure.Extensions;

public static class ProductQueryExtensions
{
    public static ProductSortArgs ArgsTo(this ProductQuery productQuery)
    {
        return new ProductSortArgs
        {
            Dimension = productQuery.Dimension,
            SortBy = productQuery.SortBy
        };
    }
}