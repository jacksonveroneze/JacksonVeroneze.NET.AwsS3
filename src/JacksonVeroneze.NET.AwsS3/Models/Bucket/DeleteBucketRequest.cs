namespace JacksonVeroneze.NET.AwsS3.Models.Bucket;

public class DeleteBucketRequest
{
    public string Name { get; }

    public DeleteBucketRequest(string name)
    {
        Name = name;
    }
}