namespace JacksonVeroneze.NET.AwsS3.Models.Bucket;

public class DeleteAwsBucketRequest
{
    public DeleteAwsBucketRequest(string name)
    {
        Name = name;
    }

    public string Name { get; }
}