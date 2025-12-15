namespace MarketPlace.API.Contracts;

public record PutProductDto(Guid Id, double Price, string Title = "",
                                string Description = "");