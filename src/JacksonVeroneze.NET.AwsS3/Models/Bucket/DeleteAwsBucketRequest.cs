namespace JacksonVeroneze.NET.AwsS3.Models.Bucket;

public class DeleteAwsBucketRequest
{
    public string Name { get; }

    public DeleteAwsBucketRequest(string name)
    {
        Name = name;
    }
}