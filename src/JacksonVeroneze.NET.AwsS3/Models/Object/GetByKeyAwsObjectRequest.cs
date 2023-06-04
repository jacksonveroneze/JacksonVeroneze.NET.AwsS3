namespace JacksonVeroneze.NET.AwsS3.Models.Object;

public class GetByKeyAwsObjectRequest
{
    private string _key;

    public string Key
    {
        get => _key;
        set => _key = Uri.UnescapeDataString(value);
    }

    public string BucketName { get; }

    public bool PreSignedUrl { get; }

    public int? PreSignedUrlExpires { get; }

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