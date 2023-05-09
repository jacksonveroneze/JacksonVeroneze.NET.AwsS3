using System.Net;
using Amazon.S3.Model;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Aws.Bucket;

[ExcludeFromCodeCoverage]
public static class PutBucketResponseBuilder
{
    public static PutBucketResponse BuildSingle()
    {
        return Factory().Generate();
    }

    private static Faker<PutBucketResponse> Factory()
    {
        return new Faker<PutBucketResponse>("pt_BR")
            .RuleFor(f => f.HttpStatusCode, HttpStatusCode.OK);
    }
}