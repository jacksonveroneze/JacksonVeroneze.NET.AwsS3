namespace JacksonVeroneze.NET.AwsS3.Entities;

public class S3Object
{
    public S3Object(string name, string? url = null)
    {
        Name = name;
        Url = url;
    }

    public string Name { get; }

    public string? Url { get; }
}