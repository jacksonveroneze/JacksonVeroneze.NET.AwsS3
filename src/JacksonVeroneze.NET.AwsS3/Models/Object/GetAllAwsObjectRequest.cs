namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class GetAllAwsObjectRequest
{
    public string BucketName { get; }

    public bool PreSignedUrl { get; }

    public int? PreSignedUrlExpires { get; }
    
    public GetAllAwsObjectRequest(
        string bucketName,
        bool preSignedUrl = false,
        int? preSignedUrlExpires = null)
    {
        BucketName = bucketName;
        PreSignedUrl = preSignedUrl;
        PreSignedUrlExpires = preSignedUrlExpires;
    }
}