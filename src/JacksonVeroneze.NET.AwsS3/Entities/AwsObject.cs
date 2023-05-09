namespace JacksonVeroneze.NET.AwsS3.Entities;

public class AwsObject
{
    public string Name { get; }

    public string Url { get; }

    public AwsObject(string name, string url)
    {
        Name = name;
        Url = url;
    }
}