using Amazon.S3;
using JacksonVeroneze.NET.AwsS3.Entities;
using JacksonVeroneze.NET.AwsS3.Interfaces;
using JacksonVeroneze.NET.AwsS3.Models.Object;
using Microsoft.Extensions.Logging;

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

    public Task<ICollection<AwsObject>> GetAllAsync(
        ObjectAllRequest request, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<AwsObject> GetByIdAsync(
        GetObjectByIdRequest request, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(
        CreateObjectRequest request, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(
        DeleteObjectRequest request, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}