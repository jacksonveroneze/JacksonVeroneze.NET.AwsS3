namespace JacksonVeroneze.NET.AwsS3.Models.Bucket;

public class CreateAwsBucketRequest
{
    public CreateAwsBucketRequest(string name)
    {
        Name = name;
    }

    public string Name { get; }
}