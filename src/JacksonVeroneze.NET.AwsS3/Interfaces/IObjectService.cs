using JacksonVeroneze.NET.AwsS3.Entities;
using JacksonVeroneze.NET.AwsS3.Models;
using JacksonVeroneze.NET.AwsS3.Models.Object;

namespace JacksonVeroneze.NET.AwsS3.Interfaces;

public interface IObjectService
{
    Task<ICollection<AwsObject>> GetAllAsync(
        ObjectAllRequest request,
        CancellationToken cancellationToken = default);

    Task<AwsObject> GetByIdAsync(
        GetObjectByIdRequest request,
        CancellationToken cancellationToken = default);

    Task CreateAsync(
        CreateObjectRequest request,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        DeleteObjectRequest request,
        CancellationToken cancellationToken = default);
}