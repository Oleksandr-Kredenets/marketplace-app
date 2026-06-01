namespace MarketPlace.Application.Dto;
public record ProductDataRequest(Guid Id,
                                 string Title,
                                 double Price,
                                 string Description);