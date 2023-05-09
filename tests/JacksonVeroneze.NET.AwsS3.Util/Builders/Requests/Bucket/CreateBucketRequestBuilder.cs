using JacksonVeroneze.NET.AwsS3.Models.Bucket;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Requests.Bucket;

[ExcludeFromCodeCoverage]
public static class CreateBucketRequestBuilder
{
    public static CreateAwsBucketRequest BuildSingle()
    {
        return Factory().Generate();
    }

    private static Faker<CreateAwsBucketRequest> Factory()
    {
        return new Faker<CreateAwsBucketRequest>("pt_BR")
            .CustomInstantiator(s =>
                new CreateAwsBucketRequest(s.Random.Word()));
    }
}