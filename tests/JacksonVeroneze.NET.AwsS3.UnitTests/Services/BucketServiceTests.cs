using System.Net;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using JacksonVeroneze.NET.AwsS3.Models.Bucket;
using JacksonVeroneze.NET.AwsS3.Services;
using JacksonVeroneze.NET.AwsS3.Util;
using JacksonVeroneze.NET.AwsS3.Util.Builders.Aws.Acl;
using JacksonVeroneze.NET.AwsS3.Util.Builders.Aws.Bucket;
using JacksonVeroneze.NET.AwsS3.Util.Builders.Requests.Bucket;
using Microsoft.Extensions.Logging;
using S3Bucket = JacksonVeroneze.NET.AwsS3.Entities.S3Bucket;

namespace JacksonVeroneze.NET.AwsS3.UnitTests.Services;

[ExcludeFromCodeCoverage]
public class BucketServiceTests
{
    private readonly Mock<IAmazonS3> _mockAmazonS3;
    private readonly Mock<ILogger<BucketService>> _mockLogger;

    private readonly BucketService _service;

    public BucketServiceTests()
    {
        _mockLogger = new Mock<ILogger<BucketService>>();
        _mockAmazonS3 = new Mock<IAmazonS3>();

        _mockLogger
            .Setup(mock => mock.IsEnabled(LogLevel.Debug))
            .Returns(true);

        _service = new BucketService(
            _mockLogger.Object,
            _mockAmazonS3.Object);
    }

    #region GetAllAsync

    [Fact(DisplayName = nameof(BucketService)
                        + nameof(BucketService.GetAllAsync)
                        + "return data")]
    public async Task GetAllAsync_ReturnDataAsync()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        GetAllAwsBucketRequest request = GetAllAwsBucketRequestBuilder
            .BuildSingle();

        ListBucketsResponse expected = ListBucketsResponseBuilder
            .BuildSingle(10);

        _mockAmazonS3.Setup(mock =>
                mock.ListBucketsAsync(
                    It.IsAny<ListBucketsRequest>(),
                    It.IsAny<CancellationToken>()))
            .Callback((ListBucketsRequest requestCb, CancellationToken _) =>
            {
                requestCb.Should()
                    .NotBeNull();
            })
            .ReturnsAsync(expected);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        ICollection<S3Bucket> result = await _service
            .GetAllAsync(request)
            .ConfigureAwait(false);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        result.Should()
            .NotBeNull()
            .And.HaveSameCount(expected.Buckets);

        _mockAmazonS3.Verify(mock =>
            mock.ListBucketsAsync(
                It.IsAny<ListBucketsRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

        _mockLogger.Verify(nameof(BucketService.GetAllAsync),
            times: Times.Once, expectedLogLevel: LogLevel.Debug);
    }

    #endregion

    #region CreateAsync

    [Fact(DisplayName = nameof(BucketService)
                        + nameof(BucketService.CreateAsync)
                        + "create sucess")]
    public async Task CreateAsync_SucessAsync()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        CreateAwsBucketRequest request = CreateAwsBucketRequestBuilder
            .BuildSingle();

        PutBucketResponse expected = PutBucketResponseBuilder
            .BuildSingle();

        _mockAmazonS3.Setup(mock =>
                mock.PutBucketAsync(
                    It.IsAny<PutBucketRequest>(),
                    It.IsAny<CancellationToken>()))
            .Callback((PutBucketRequest requestCb, CancellationToken _) =>
            {
                requestCb.Should()
                    .NotBeNull();
            })
            .ReturnsAsync(expected);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        await _service.CreateAsync(request)
            .ConfigureAwait(false);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        _mockAmazonS3.Verify(mock =>
            mock.PutBucketAsync(
                It.IsAny<PutBucketRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

        _mockLogger.Verify(nameof(BucketService.CreateAsync),
            times: Times.Once, expectedLogLevel: LogLevel.Debug);
    }

    #endregion

    #region DeleteAsync

    [Fact(DisplayName = nameof(BucketService)
                        + nameof(BucketService.DeleteAsync)
                        + "delete sucess")]
    public async Task DeleteAsync_SucessAsync()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        DeleteAwsBucketRequest request = DeleteAwsBucketRequestBuilder
            .BuildSingle();

        DeleteBucketResponse expected = DeleteBucketResponseBuilder
            .BuildSingle();

        _mockAmazonS3.Setup(mock =>
                mock.DeleteBucketAsync(
                    It.IsAny<DeleteBucketRequest>(),
                    It.IsAny<CancellationToken>()))
            .Callback((DeleteBucketRequest requestCb, CancellationToken _) =>
            {
                requestCb.Should()
                    .NotBeNull();
            })
            .ReturnsAsync(expected);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        await _service.DeleteAsync(request);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        _mockAmazonS3.Verify(mock =>
            mock.DeleteBucketAsync(
                It.IsAny<DeleteBucketRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

        _mockLogger.Verify(nameof(BucketService.DeleteAsync),
            times: Times.Once, expectedLogLevel: LogLevel.Debug);
    }

    #endregion

    #region ExistsAsync

    [Fact(DisplayName = nameof(BucketService)
                        + nameof(BucketService.ExistsAsync)
                        + "exists true - success")]
    public async Task Exists_True_SucessAsync()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        string bucketName = Guid.NewGuid().ToString();

        GetACLResponse expected = GetAclResponseBuilder.BuildSingle();

        _mockAmazonS3.Setup(mock =>
                mock.GetACLAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .Callback((string bucketNameCb, CancellationToken _) =>
            {
                bucketNameCb.Should()
                    .NotBeNullOrEmpty();
            })
            .ReturnsAsync(expected);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        bool exists = await _service.ExistsAsync(bucketName);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        exists.Should()
            .BeTrue();

        _mockAmazonS3.Verify(mock =>
            mock.GetACLAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()), Times.Once);

        _mockLogger.Verify(nameof(BucketService.ExistsAsync),
            times: Times.Once, expectedLogLevel: LogLevel.Debug);
    }

    [Fact(DisplayName = nameof(BucketService)
                        + nameof(BucketService.ExistsAsync)
                        + "exists false - success")]
    public async Task Exists_False_SucessAsync()
    {
        // -------------------------------------------------------
        // Arrange
        // -------------------------------------------------------
        string bucketName = Guid.NewGuid().ToString();

        AmazonS3Exception expected = new("NoSuchBucket",
            ErrorType.Unknown, "NoSuchBucket", "1",
            HttpStatusCode.InternalServerError);

        _mockAmazonS3.Setup(mock =>
                mock.GetACLAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .Callback((string bucketNameCb, CancellationToken _) =>
            {
                bucketNameCb.Should()
                    .NotBeNullOrEmpty();
            })
            .ThrowsAsync(expected);

        // -------------------------------------------------------
        // Act
        // -------------------------------------------------------
        bool exists = await _service.ExistsAsync(bucketName);

        // -------------------------------------------------------
        // Assert
        // -------------------------------------------------------
        exists.Should()
            .BeFalse();

        _mockAmazonS3.Verify(mock =>
            mock.GetACLAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()), Times.Once);

        _mockLogger.Verify(nameof(BucketService.ExistsAsync),
            times: Times.Once, expectedLogLevel: LogLevel.Debug);
    }

    #endregion
}