namespace MarketPlace.Domain.Collections;
public record ProductQuery{
    public string? SortBy { get; init; }
    public int? Dimension { get; init; }
    }