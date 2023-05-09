using System.Net;
using Amazon.S3.Model;

namespace JacksonVeroneze.NET.AwsS3.Util.Builders.Aws.Acl;

[ExcludeFromCodeCoverage]
public static class GetACLResponseBuilder
{
    public static GetACLResponse BuildSingle(
        HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return Factory(statusCode).Generate();
    }

    private static Faker<GetACLResponse> Factory(
        HttpStatusCode statusCode)
    {
        return new Faker<GetACLResponse>("pt_BR")
            .RuleFor(f => f.HttpStatusCode, statusCode);
    }
}