namespace Database.Models;

public class User : IEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<Article> Articles { get; set; } = null!;
}