namespace MarketPlace.API.Contracts;

public record PostProductDto(Guid UserId, string Title, double Price,
                                 string Description = "");