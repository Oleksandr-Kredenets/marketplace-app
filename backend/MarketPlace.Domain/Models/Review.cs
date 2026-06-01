namespace MarketPlace.Domain.Models;

public class Review
{
    public Review(Guid userId, string text, int rating)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Text = text;
        Rating = rating;
    }
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
}