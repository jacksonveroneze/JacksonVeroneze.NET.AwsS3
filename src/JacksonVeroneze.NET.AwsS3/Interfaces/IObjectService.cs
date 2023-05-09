using JacksonVeroneze.NET.AwsS3.Entities;
using JacksonVeroneze.NET.AwsS3.Models.Object;

namespace JacksonVeroneze.NET.AwsS3.Interfaces;

public interface IObjectService
{
    Task<ICollection<AwsObject>> GetAllAsync(
        GetAllAwsObjectRequest request,
        CancellationToken cancellationToken = default);

    Task<AwsObject> GetByIdAsync(
        GetByIdAwsObjectRequest request,
        CancellationToken cancellationToken = default);

    Task CreateAsync(
        CreateAwsObjectRequest request,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        DeleteAwsObjectRequest request,
        CancellationToken cancellationToken = default);
}