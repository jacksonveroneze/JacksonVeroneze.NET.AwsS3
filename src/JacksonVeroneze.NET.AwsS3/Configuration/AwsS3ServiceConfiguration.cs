using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Dawn;

namespace JacksonVeroneze.NET.AwsS3.Configuration;

public sealed class AwsS3ServiceConfiguration
{
    public bool? LocalMode { get; set; }

    #region Run - Aws

    private AWSOptions? _awsOptions;

    public AWSOptions? AwsOptions
    {
        get => _awsOptions;
        set
        {
            ArgumentNullException.ThrowIfNull(LocalMode, nameof(LocalMode));
            Guard.Argument(LocalMode).False();

            _awsOptions = value;
        }
    }

    #endregion

    #region Run - LocalStack

    private RegionEndpoint? _awsRegion;
    private string? _serviceUrl;
    private bool? _forcePathStyle;

    public RegionEndpoint? AwsRegion
    {
        get => _awsRegion;
        set
        {
            ArgumentNullException.ThrowIfNull(LocalMode, nameof(LocalMode));
            Guard.Argument(LocalMode).True();

            _awsRegion = value;
        }
    }

    public string? ServiceUrl
    {
        get => _serviceUrl;
        set
        {
            ArgumentNullException.ThrowIfNull(LocalMode, nameof(LocalMode));
            Guard.Argument(LocalMode).True();

            _serviceUrl = value;
        }
    }

    public bool? ForcePathStyle
    {
        get => _forcePathStyle;
        set
        {
            ArgumentNullException.ThrowIfNull(LocalMode, nameof(LocalMode));
            Guard.Argument(LocalMode).True();

            _forcePathStyle = value;
        }
    }

    #endregion
}