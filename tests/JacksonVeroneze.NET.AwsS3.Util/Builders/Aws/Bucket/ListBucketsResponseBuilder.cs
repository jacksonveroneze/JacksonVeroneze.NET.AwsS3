using Amazon.S3.Model;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Aws.Bucket;

[ExcludeFromCodeCoverage]
public static class ListBucketsResponseBuilder
{
    public static ListBucketsResponse BuildSingle(
        int qtdBuckets)
    {
        return Factory(qtdBuckets).Generate();
    }

    private static Faker<ListBucketsResponse> Factory(
        int qtdBuckets)
    {
        return new Faker<ListBucketsResponse>("pt_BR")
            .RuleFor(f => f.Buckets, S3BucketBuilder.BuildMany(qtdBuckets));
    }
}