namespace JacksonVeroneze.NET.AwsS3.Entities;

public class Bucket
{
    public string Name { get; }
    
    public DateTime CreatedAt { get; }

    public Bucket(string name, DateTime createdAt)
    {
        Name = name;
        CreatedAt = createdAt;
    }
}