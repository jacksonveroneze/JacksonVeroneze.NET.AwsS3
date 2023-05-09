namespace JacksonVeroneze.NET.AwsS3.Entities;

public class AwsBucket
{
    public string Name { get; }
    
    public DateTime CreatedAt { get; }

    public AwsBucket(string name, DateTime createdAt)
    {
        Name = name;
        CreatedAt = createdAt;
    }
}