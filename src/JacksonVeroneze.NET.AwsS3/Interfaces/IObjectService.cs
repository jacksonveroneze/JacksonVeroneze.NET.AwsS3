using JacksonVeroneze.NET.AwsS3.Entities;
using JacksonVeroneze.NET.AwsS3.Models.Object;

namespace JacksonVeroneze.NET.AwsS3.Interfaces;

public interface IObjectService
{
    Task<ICollection<S3Object>> GetAllAsync(
        GetAllAwsObjectRequest request,
        CancellationToken cancellationToken = default);

    Task<S3Object> GetByKeyAsync(
        GetByKeyAwsObjectRequest request,
        CancellationToken cancellationToken = default);

    Task CreateAsync(
        CreateAwsObjectRequest request,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        DeleteAwsObjectRequest request,
        CancellationToken cancellationToken = default);
}