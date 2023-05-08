namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class GetObjectByIdRequest
{
    public string BucketName { get; }

    public string Key { get; }

    public GetObjectByIdRequest(string bucketName, string key)
    {
        BucketName = bucketName;
        Key = key;
    }
}