namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class CreateAwsObjectRequest
{
    public string BucketName { get; }

    public string Prefix { get; }

    public string Name { get; }

    public string Content { get; }

    public IDictionary<string, string> Metadata { get; }

    public string FullPath => $"{Prefix}/{Name}";

    public CreateAwsObjectRequest(string bucketName,
        string prefix, string name, string content,
        IDictionary<string, string> metadata)
    {
        BucketName = bucketName;
        Prefix = prefix;
        Name = name;
        Content = content;
        Metadata = metadata;
    }
}