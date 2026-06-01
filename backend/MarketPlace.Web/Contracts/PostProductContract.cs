namespace MarketPlace.Web.Contracts;

public record PostProductContract(Guid UserId,
                                  string Title,
                                  double Price,
                                  IFormFile Image,
                                  string Description = "");