using Amazon.S3.Model;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Aws.Bucket;

[ExcludeFromCodeCoverage]
public static class S3BucketBuilder
{
    public static ICollection<S3Bucket> BuildMany(
        int? qtde = null)
    {
        if (qtde is null)
        {
            qtde = new Random().Next(1, 20);
        }

        return Factory().Generate(qtde.Value);
    }

    private static Faker<S3Bucket> Factory()
    {
        return new Faker<S3Bucket>("pt_BR")
            .RuleFor(f => f.BucketName, s => s.Person.FullName)
            .RuleFor(f => f.CreationDate, s => s.Date.Recent());
    }
}