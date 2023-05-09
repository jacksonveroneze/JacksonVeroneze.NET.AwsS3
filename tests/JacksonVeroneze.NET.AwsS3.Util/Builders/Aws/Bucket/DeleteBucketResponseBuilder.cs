using System.Net;
using Amazon.S3.Model;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Aws.Bucket;

[ExcludeFromCodeCoverage]
public static class DeleteBucketResponseBuilder
{
    public static DeleteBucketResponse BuildSingle()
    {
        return Factory().Generate();
    }

    private static Faker<DeleteBucketResponse> Factory()
    {
        return new Faker<DeleteBucketResponse>("pt_BR")
            .RuleFor(f => f.HttpStatusCode, HttpStatusCode.OK);
    }
}