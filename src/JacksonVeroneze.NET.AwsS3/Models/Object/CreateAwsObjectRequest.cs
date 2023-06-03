namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class CreateAwsObjectRequest
{
    public CreateAwsObjectRequest(string bucketName,
        string prefix, string name, MemoryStream content,
        IDictionary<string, string> metadata,
        IDictionary<string, string> tags)
    {
        BucketName = bucketName;
        Prefix = prefix;
        Name = name;
        Content = content;
        Metadata = metadata;
        Tags = tags;
    }

    public string BucketName { get; }

    public string Prefix { get; }

    public string Name { get; }

    public MemoryStream Content { get; }

    public IDictionary<string, string> Metadata { get; }

    public IDictionary<string, string> Tags { get; }

    public string Key => $"{Prefix}/{Name}";
}