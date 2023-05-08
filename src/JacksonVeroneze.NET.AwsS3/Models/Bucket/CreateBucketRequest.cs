namespace JacksonVeroneze.NET.AwsS3.Models.Bucket;

public class CreateBucketRequest
{
    public string Name { get; }

    public CreateBucketRequest(string name)
    {
        Name = name;
    }
}