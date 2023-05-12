using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Dawn;
using Guard = Dawn.Guard;

namespace JacksonVeroneze.NET.AwsS3.Configuration;

public sealed class AwsS3ServiceConfiguration
{
    public bool? LocalMode { get; init; }

    #region Run - Aws

    private readonly AWSOptions? _awsOptions;

    public AWSOptions? AwsOptions
    {
        get => _awsOptions;
        init
        {
            ArgumentNullException.ThrowIfNull(LocalMode, nameof(LocalMode));
            Guard.Argument(LocalMode).False();

            _awsOptions = value;
        }
    }

    #endregion

    #region Run - LocalStack

    private readonly RegionEndpoint? _awsRegion;
    private readonly string? _serviceUrl;
    private readonly bool? _forcePathStyle;

    public RegionEndpoint? AwsRegion
    {
        get => _awsRegion;
        init
        {
            ArgumentNullException.ThrowIfNull(LocalMode, nameof(LocalMode));
            Guard.Argument(LocalMode).True();

            _awsRegion = value;
        }
    }

    public string? ServiceUrl
    {
        get => _serviceUrl;
        init
        {
            ArgumentNullException.ThrowIfNull(LocalMode, nameof(LocalMode));
            Guard.Argument(LocalMode).True();

            _serviceUrl = value;
        }
    }

    public bool? ForcePathStyle
    {
        get => _forcePathStyle;
        init
        {
            ArgumentNullException.ThrowIfNull(LocalMode, nameof(LocalMode));
            Guard.Argument(LocalMode).True();

            _forcePathStyle = value;
        }
    }

    #endregion
}