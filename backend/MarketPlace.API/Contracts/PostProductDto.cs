namespace MarketPlace.API.Contracts;

public record PostProductDto(Guid UserId, double Price, string Title = "",
                                 string Description = "");