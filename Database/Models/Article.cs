namespace Database.Models;

public class Article : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Body { get; set; } = null!;
    
    public int TopicId { get; set; }
    public Topic Topic { get; set; } = null!;
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
}