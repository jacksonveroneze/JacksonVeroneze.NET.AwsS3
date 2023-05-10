using JacksonVeroneze.NET.AwsS3.Models.Bucket;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Requests.Bucket;

[ExcludeFromCodeCoverage]
public static class GetAllAwsBucketRequestBuilder
{
    public static GetAllAwsBucketRequest BuildSingle()
    {
        return Factory().Generate();
    }

    private static Faker<GetAllAwsBucketRequest> Factory()
    {
        return new Faker<GetAllAwsBucketRequest>("pt_BR");
    }
}