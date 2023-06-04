using System.Security.Cryptography;
using JacksonVeroneze.NET.AwsS3.Entities;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Entities.Bucket;

[ExcludeFromCodeCoverage]
public static class S3BucketBuilder
{
    public static S3Bucket BuildSingle()
    {
        return Factory().Generate();
    }

    public static ICollection<S3Bucket> BuildMany(
        int? qtde = null)
    {
        qtde ??= RandomNumberGenerator.GetInt32(5, 10);

        return Factory().Generate(qtde.Value);
    }

    private static Faker<S3Bucket> Factory()
    {
        return new Faker<S3Bucket>("pt_BR")
            .RuleFor(f => f.Name, s => s.Random.Word())
            .RuleFor(f => f.CreatedAt, s => s.Date.Recent());
    }
}