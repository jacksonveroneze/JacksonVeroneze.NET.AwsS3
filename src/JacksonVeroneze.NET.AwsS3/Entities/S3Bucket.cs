namespace JacksonVeroneze.NET.AwsS3.Entities;

public class S3Bucket
{
    public string Name { get; }

    public DateTime CreatedAt { get; }

    public S3Bucket(string name, DateTime createdAt)
    {
        Name = name;
        CreatedAt = createdAt;
    }
}