namespace MarketPlace.Application.Dto;
public record ProductRequest(Guid UserId,
                             string Title,
                             double Price,
                             Stream Image,
                             string Description = "");