using JacksonVeroneze.NET.AwsS3.Entities;
using JacksonVeroneze.NET.AwsS3.Models;
using JacksonVeroneze.NET.AwsS3.Models.Bucket;

namespace JacksonVeroneze.NET.AwsS3.Interfaces;

public interface IBucketService
{
    Task<ICollection<AwsBucket>> GetAllAsync(
        BucketAllRequest request,
        CancellationToken cancellationToken = default);
    
    Task CreateAsync(
        CreateBucketRequest request, 
        CancellationToken cancellationToken = default);
    
    Task DeleteAsync(
        DeleteBucketRequest request, 
        CancellationToken cancellationToken = default);
    
    Task<bool> ExistsAsync(string name);
}