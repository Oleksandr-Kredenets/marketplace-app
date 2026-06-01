namespace MarketPlace.Application.Dto;
public record ProductResponse (Guid Id,
                               Guid UserId,
                               string Title,
                               double Price,
                               string Description,
                               string Slug,
                               string ImageUrl);