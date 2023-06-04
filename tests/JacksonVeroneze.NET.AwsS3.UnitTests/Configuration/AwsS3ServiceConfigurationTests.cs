using Amazon.Extensions.NETCore.Setup;
using JacksonVeroneze.NET.AwsS3.Configuration;

namespace JacksonVeroneze.NET.AwsS3.UnitTests.Configuration;

[ExcludeFromCodeCoverage]
public class AwsS3ServiceConfigurationTests
{
    #region AwsOptions

    [Fact(DisplayName = nameof(AwsS3ServiceConfiguration.AwsOptions)
                        + "Not defined param: LocalMode - ThrowException")]
    public void AwsOptions_NotDefinedLocalMode_ThrowException()
    {
        // -------------------------------------------------------
        // Arrange && Act
        // -------------------------------------------------------
        Action action = () => { };

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentNullException>();
    }

    [Fact(DisplayName = nameof(AwsS3ServiceConfiguration.AwsOptions)
                        + "LocalMode is true - ThrowException")]
    public void AwsOptions_LocalModeIsTrue_ThrowException()
    {
        // -------------------------------------------------------
        // Arrange && Act
        // -------------------------------------------------------
        Action action = () =>
        {
            new AwsS3ServiceConfiguration()
            {
                LocalMode = true,
                AwsOptions = new AWSOptions()
            };
        };

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        action.Should()
            .ThrowExactly<ArgumentException>();
    }

    [Fact(DisplayName = nameof(AwsS3ServiceConfiguration.AwsOptions)
                        + "Success")]
    public void AwsOptions_Sucess()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        AWSOptions options = new();

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        AwsS3ServiceConfiguration config = new()
        {
            LocalMode = false,
            AwsOptions = options
        };

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        config.AwsOptions.Should()
            .NotBeNull()
            .And.BeEquivalentTo(options);
    }

    #endregion
}