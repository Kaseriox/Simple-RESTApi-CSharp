namespace Database.Models;

public class Topic : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Created { get; set; }
    
}