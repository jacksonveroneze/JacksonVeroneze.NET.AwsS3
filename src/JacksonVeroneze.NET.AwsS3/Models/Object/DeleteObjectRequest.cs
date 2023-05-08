namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class DeleteObjectRequest
{
    public string BucketName { get; }

    public string Key { get; }

    public DeleteObjectRequest(string bucketName, string key)
    {
        BucketName = bucketName;
        Key = key;
    }
}