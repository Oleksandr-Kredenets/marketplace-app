using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Domain.Models;

public class Review
{
    public Review(Guid userId, string text, int rating)
    {
        this.Id = Guid.NewGuid();
        this.UserId = userId;
        this.Text = text;
        this.Rating = rating;
    }
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
}