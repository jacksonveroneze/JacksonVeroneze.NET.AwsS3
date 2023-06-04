using Amazon.S3;
using Amazon.S3.Model;
using JacksonVeroneze.NET.AwsS3.Extensions;
using JacksonVeroneze.NET.AwsS3.Interfaces;
using JacksonVeroneze.NET.AwsS3.Models.Object;
using Microsoft.Extensions.Logging;
using S3Object = JacksonVeroneze.NET.AwsS3.Entities.S3Object;

namespace JacksonVeroneze.NET.AwsS3.Services;

public class ObjectService : IObjectService
{
    private readonly ILogger<ObjectService> _logger;
    private readonly IAmazonS3 _s3Client;

    public ObjectService(
        ILogger<ObjectService> logger,
        IAmazonS3 s3Client)
    {
        _logger = logger;
        _s3Client = s3Client;
    }

    public async Task<ICollection<S3Object>> GetAllAsync(
        GetAllAwsObjectRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        try
        {
            ListObjectsV2Request requestAws =
                new() { BucketName = request.BucketName };

            ListObjectsV2Response result = await _s3Client
                .ListObjectsV2Async(requestAws, cancellationToken)
                .ConfigureAwait(false);

            ICollection<S3Object> objects = result.S3Objects
                .Select(item =>
                {
                    string? url = !request.PreSignedUrl
                        ? null
                        : GetPreSignedUrl(item.BucketName, item.Key,
                            request.PreSignedUrlExpires!.Value);

                    return new S3Object(item.Key, url);
                }).ToArray();

            _logger.LogGetAllObjects(nameof(BucketService),
                nameof(DeleteAsync), request.BucketName, objects.Count);

            return objects;
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

    public async Task<S3Object> GetByKeyAsync(
        GetByKeyAwsObjectRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        try
        {
            GetObjectRequest requestAws = new()
            {
                BucketName = request.BucketName,
                Key = request.Key
            };

            GetObjectResponse result = await _s3Client
                .GetObjectAsync(requestAws, cancellationToken)
                .ConfigureAwait(false);

            string? url = !request.PreSignedUrl
                ? null
                : GetPreSignedUrl(request.BucketName, request.Key,
                    request.PreSignedUrlExpires!.Value);

            S3Object s3Object = new(result.Key, url);

            _logger.LogGetObjectBykey(nameof(BucketService),
                nameof(DeleteAsync), request.BucketName, request.Key);

            return s3Object;
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
        CreateAwsObjectRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        try
        {
            PutObjectRequest requestAws = new()
            {
                BucketName = request.BucketName,
                Key = request.Key,
                ContentBody = request.Content.ToString()
            };

            foreach (KeyValuePair<string, string> item in request.Metadata)
            {
                requestAws.Metadata.Add(item.Key, item.Value);
            }

            foreach (KeyValuePair<string, string> item in request.Metadata)
            {
                requestAws.TagSet.Add(new Tag { Key = item.Key, Value = item.Value });
            }

            await _s3Client
                .PutObjectAsync(requestAws, cancellationToken)
                .ConfigureAwait(false);

            _logger.LogCreateObject(nameof(BucketService),
                nameof(DeleteAsync), request.BucketName, request.Key);
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
        DeleteAwsObjectRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        try
        {
            DeleteObjectRequest requestAws = new()
            {
                BucketName = request.BucketName,
                Key = request.Key
            };

            await _s3Client
                .DeleteObjectAsync(requestAws, cancellationToken)
                .ConfigureAwait(false);

            _logger.LogDeleteObject(nameof(BucketService),
                nameof(DeleteAsync), request.BucketName, request.Key);
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

    #region Common

    private string GetPreSignedUrl(string bucketName,
        string key, int expiries)
    {
        GetPreSignedUrlRequest urlRequest = new()
        {
            BucketName = bucketName,
            Key = key,
            Expires = DateTime.UtcNow.AddMinutes(expiries)
        };

        return _s3Client.GetPreSignedURL(urlRequest);
    }

    #endregion
}