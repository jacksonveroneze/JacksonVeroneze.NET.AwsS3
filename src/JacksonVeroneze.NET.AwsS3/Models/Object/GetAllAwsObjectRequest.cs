namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class GetAllAwsObjectRequest
{
    public GetAllAwsObjectRequest(
        string bucketName,
        bool preSignedUrl = false,
        int? preSignedUrlExpires = null)
    {
        BucketName = bucketName;
        PreSignedUrl = preSignedUrl;
        PreSignedUrlExpires = preSignedUrlExpires;
    }

    public string BucketName { get; }

    public bool PreSignedUrl { get; }

    public int? PreSignedUrlExpires { get; }
}