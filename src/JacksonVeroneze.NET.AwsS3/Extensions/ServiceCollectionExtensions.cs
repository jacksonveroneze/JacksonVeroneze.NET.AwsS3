using System.Diagnostics.CodeAnalysis;
using Amazon.S3;
using JacksonVeroneze.NET.AwsS3.Configuration;
using JacksonVeroneze.NET.AwsS3.Interfaces;
using JacksonVeroneze.NET.AwsS3.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JacksonVeroneze.NET.AwsS3.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAwsS3Service(
        this IServiceCollection services,
        Action<AwsS3ServiceConfiguration> config)
    {
        AwsS3ServiceConfiguration conf = new();

        config.Invoke(conf);

        if (conf.LocalMode is true)
        {
            services.AddSingleton<IAmazonS3>(_ =>
            {
                AmazonS3Config awsS3Config = new()
                {
                    RegionEndpoint = conf.AwsRegion,
                    ServiceURL = conf.ServiceUrl,
                    ForcePathStyle = conf.ForcePathStyle!.Value
                };

                return new AmazonS3Client(awsS3Config);
            });
        }
        else
        {
            services.TryAddAWSService<IAmazonS3>(
                conf.AwsOptions);
        }

        services.AddTransient<IBucketService, BucketService>();
        services.AddTransient<IObjectService, ObjectService>();

        return services;
    }
}