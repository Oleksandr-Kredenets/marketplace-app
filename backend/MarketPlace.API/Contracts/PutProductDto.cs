namespace MarketPlace.API.Contracts;

public record PutProductDto(Guid Id, string Title, double Price,
                                string Description = "");