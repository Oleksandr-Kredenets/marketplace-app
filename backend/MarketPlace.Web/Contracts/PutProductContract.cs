namespace MarketPlace.Web.Contracts;

public record PutProductContract(Guid Id,
                                 string Title,
                                 double Price,
                                 string Description = "");