using JacksonVeroneze.NET.AwsS3.Entities;
using JacksonVeroneze.NET.AwsS3.Models.Bucket;

namespace JacksonVeroneze.NET.AwsS3.Interfaces;

public interface IBucketService
{
    Task<ICollection<S3Bucket>> GetAllAsync(
        GetAllAwsBucketRequest request,
        CancellationToken cancellationToken = default);

    Task CreateAsync(
        CreateAwsBucketRequest request,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        DeleteAwsBucketRequest request,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(string name);
}