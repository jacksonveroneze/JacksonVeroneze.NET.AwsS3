using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using JacksonVeroneze.NET.AwsS3.Entities;
using JacksonVeroneze.NET.AwsS3.Extensions;
using JacksonVeroneze.NET.AwsS3.Interfaces;
using JacksonVeroneze.NET.AwsS3.Models.Bucket;
using Microsoft.Extensions.Logging;
using DeleteBucketRequest = JacksonVeroneze.NET.AwsS3.Models.Bucket.DeleteBucketRequest;
using DeleteBucketRequestAws = Amazon.S3.Model.DeleteBucketRequest;


namespace JacksonVeroneze.NET.AwsS3.Services;

public class BucketService : IBucketService
{
    private readonly ILogger<BucketService> _logger;
    private readonly IAmazonS3 _s3Client;

    public BucketService(
        ILogger<BucketService> logger,
        IAmazonS3 s3Client)
    {
        _logger = logger;
        _s3Client = s3Client;
    }

    public async Task<ICollection<Bucket>> GetPagedAsync(
        BucketPagedRequest request,
        CancellationToken cancellationToken = default)
    {
        ListBucketsRequest requestAws = new();

        ListBucketsResponse result = await _s3Client
            .ListBucketsAsync(requestAws, cancellationToken);

        ICollection<Bucket> buckets =
            result.Buckets.Select(bucket => new Bucket(
                    bucket.BucketName, bucket.CreationDate))
                .ToArray();

        _logger.LogGetPaged(nameof(BucketService),
            nameof(GetPagedAsync), buckets.Count);

        return buckets;
    }

    public async Task CreateAsync(
        CreateBucketRequest request,
        CancellationToken cancellationToken = default)
    {
        PutBucketRequest requestAws = new()
        {
            BucketName = request.Name,
            UseClientRegion = true
        };

        await _s3Client.PutBucketAsync(
            requestAws, cancellationToken);

        _logger.LogCreateBucket(nameof(BucketService),
            nameof(CreateAsync), request.Name);
    }

    public async Task DeleteAsync(
        DeleteBucketRequest request,
        CancellationToken cancellationToken = default)
    {
        DeleteBucketRequestAws requestAws = new()
        {
            BucketName = request.Name,
            UseClientRegion = true
        };

        await _s3Client.DeleteBucketAsync(
            requestAws, cancellationToken);

        _logger.LogDeleteBucket(nameof(BucketService),
            nameof(DeleteAsync), request.Name);
    }

    public async Task<bool> ExistsAsync(string name)
    {
        bool exists = await AmazonS3Util
            .DoesS3BucketExistV2Async(_s3Client, name);

        _logger.LogExistsBucket(nameof(BucketService),
            nameof(ExistsAsync), name, exists);

        return exists;
    }
}