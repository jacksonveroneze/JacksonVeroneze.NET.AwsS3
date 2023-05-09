using JacksonVeroneze.NET.AwsS3.Models.Bucket;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Requests.Bucket;

[ExcludeFromCodeCoverage]
public static class DeleteBucketRequestBuilder
{
    public static DeleteAwsBucketRequest BuildSingle()
    {
        return Factory().Generate();
    }

    private static Faker<DeleteAwsBucketRequest> Factory()
    {
        return new Faker<DeleteAwsBucketRequest>("pt_BR")
            .CustomInstantiator(s =>
                new DeleteAwsBucketRequest(s.Random.Word()));
    }
}