using JacksonVeroneze.NET.AwsS3.Entities;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Entities.Bucket;

[ExcludeFromCodeCoverage]
public static class AwsBucketBuilder
{
    public static AwsBucket BuildSingle()
    {
        return Factory().Generate();
    }

    public static ICollection<AwsBucket> BuildMany(
        int? qtde = null)
    {
        qtde ??= new Random().Next(1, 100);

        return Factory().Generate(qtde.Value);
    }

    private static Faker<AwsBucket> Factory()
    {
        return new Faker<AwsBucket>("pt_BR")
            .RuleFor(f => f.Name, s => s.Random.Word())
            .RuleFor(f => f.CreatedAt, s => s.Date.Recent());
    }
}