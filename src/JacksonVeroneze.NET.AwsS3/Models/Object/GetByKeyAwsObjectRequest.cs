namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class GetByKeyAwsObjectRequest
{
    private string _key;

    public string BucketName { get; }

    public string Key => Uri.UnescapeDataString(Key);

    public bool PreSignedUrl { get; set; }

    public int? PreSignedUrlExpires { get; set; }
    
    public GetByKeyAwsObjectRequest(string bucketName,
        string key,
        bool preSignedUrl = false,
        int? preSignedUrlExpires = null)
    {
        BucketName = bucketName;
        _key = key;
        PreSignedUrl = preSignedUrl;
        PreSignedUrlExpires = preSignedUrlExpires;
    }
}