namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class DeleteAwsObjectRequest
{
    public string BucketName { get; }

    public string Key { get; }

    public DeleteAwsObjectRequest(
        string bucketName, string key)
    {
        BucketName = bucketName;
        Key = key;
    }
}