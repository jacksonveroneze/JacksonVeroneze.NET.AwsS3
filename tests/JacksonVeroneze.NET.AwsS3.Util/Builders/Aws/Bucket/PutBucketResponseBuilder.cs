using System.Net;
using Amazon.S3.Model;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Aws.Bucket;

[ExcludeFromCodeCoverage]
public static class PutBucketResponseBuilder
{
    public static PutBucketResponse BuildSingle(
        HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return Factory(statusCode).Generate();
    }

    private static Faker<PutBucketResponse> Factory(
        HttpStatusCode statusCode)
    {
        return new Faker<PutBucketResponse>("pt_BR")
            .RuleFor(f => f.HttpStatusCode, statusCode);
    }
}