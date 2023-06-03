using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using JacksonVeroneze.NET.AwsS3.Extensions;
using JacksonVeroneze.NET.AwsS3.Interfaces;
using JacksonVeroneze.NET.AwsS3.Models.Bucket;
using Microsoft.Extensions.Logging;
using S3Bucket = JacksonVeroneze.NET.AwsS3.Entities.S3Bucket;

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

    public async Task<ICollection<S3Bucket>> GetAllAsync(
        GetAllAwsBucketRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        try
        {
            ListBucketsRequest requestAws = new();

            ListBucketsResponse result = await _s3Client
                .ListBucketsAsync(requestAws, cancellationToken);

            ICollection<S3Bucket> buckets = result.Buckets
                .Select(bucket => new S3Bucket(
                    bucket.BucketName, bucket.CreationDate))
                .ToArray();

            _logger.LogGetAllBuckets(nameof(BucketService),
                nameof(GetAllAsync), buckets.Count);

            return buckets;
        }
        catch (AmazonS3Exception ex)
        {
            _logger.LogGenericError(nameof(BucketService),
                nameof(CreateAsync), ex);

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogGenericError(nameof(BucketService),
                nameof(CreateAsync), ex);

            throw;
        }
    }

    public async Task CreateAsync(
        CreateAwsBucketRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        try
        {
            // Validar bucket name

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
        catch (AmazonS3Exception ex)
        {
            _logger.LogGenericError(nameof(BucketService),
                nameof(CreateAsync), ex);

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogGenericError(nameof(BucketService),
                nameof(CreateAsync), ex);

            throw;
        }
    }

    public async Task DeleteAsync(
        DeleteAwsBucketRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        try
        {
            DeleteBucketRequest requestAws = new()
            {
                BucketName = request.Name,
                UseClientRegion = true
            };

            await _s3Client.DeleteBucketAsync(
                requestAws, cancellationToken);

            _logger.LogDeleteBucket(nameof(BucketService),
                nameof(DeleteAsync), request.Name);
        }
        catch (AmazonS3Exception ex)
        {
            _logger.LogGenericError(nameof(BucketService),
                nameof(CreateAsync), ex);

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogGenericError(nameof(BucketService),
                nameof(CreateAsync), ex);

            throw;
        }
    }

    public async Task<bool> ExistsAsync(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

        bool exists = await AmazonS3Util
            .DoesS3BucketExistV2Async(_s3Client, name);

        _logger.LogExistsBucket(nameof(BucketService),
            nameof(ExistsAsync), name, exists);

        return exists;
    }
}