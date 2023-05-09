namespace JacksonVeroneze.NET.AwsS3.Models.Bucket;

public class CreateAwsBucketRequest
{
    public string Name { get; }

    public CreateAwsBucketRequest(string name)
    {
        Name = name;
    }
}