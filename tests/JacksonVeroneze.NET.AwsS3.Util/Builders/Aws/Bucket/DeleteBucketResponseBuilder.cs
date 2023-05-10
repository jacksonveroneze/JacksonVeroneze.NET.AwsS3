using System.Net;
using Amazon.S3.Model;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Aws.Bucket;

[ExcludeFromCodeCoverage]
public static class DeleteBucketResponseBuilder
{
    public static DeleteBucketResponse BuildSingle(
        HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return Factory(statusCode).Generate();
    }

    private static Faker<DeleteBucketResponse> Factory(
        HttpStatusCode statusCode)
    {
        return new Faker<DeleteBucketResponse>("pt_BR")
            .RuleFor(f => f.HttpStatusCode, statusCode);
    }
}