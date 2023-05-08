using Amazon;

namespace JacksonVeroneze.NET.AwsS3.Extensions;

public sealed class AwsS3ServiceConfig
{
    public bool LocalMode { get; init; }

    public RegionEndpoint? AwsRegion { get; init; }
    
    public string? ServiceUrl { get; init; }
    
    public bool ForcePathStyle { get; init; }
}