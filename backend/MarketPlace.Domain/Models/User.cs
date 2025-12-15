namespace MarketPlace.Domain.Models;

public class User
{
    public User(){}
    public User(string username)
    {
        Id = Guid.NewGuid();
        Username = username;
    }

    public Guid Id { get; set; }
    public required string Username { get; set; }
}