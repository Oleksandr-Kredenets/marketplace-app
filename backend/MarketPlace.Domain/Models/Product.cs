namespace MarketPlace.Domain.Models;

public class Product
{
    public Product(Guid userId, string title, double price, string description)//, string imageUrl)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Title = title;
        Price = price;
        Description = description;
        //ImageUrl = imageUrl;
    }
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    //public string ImageUrl { get; set; }
}