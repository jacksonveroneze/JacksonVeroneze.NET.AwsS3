namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class GetByIdAwsObjectRequest
{
    public string BucketName { get; }

    public string Key { get; }

    public GetByIdAwsObjectRequest(string bucketName, string key)
    {
        BucketName = bucketName;
        Key = key;
    }
}