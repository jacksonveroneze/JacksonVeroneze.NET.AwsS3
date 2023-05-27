namespace JacksonVeroneze.NET.AwsS3.Entities;

public class S3Object
{
    public string Name { get; }

    public string Url { get; }

    public S3Object(string name, string url)
    {
        Name = name;
        Url = url;
    }
}