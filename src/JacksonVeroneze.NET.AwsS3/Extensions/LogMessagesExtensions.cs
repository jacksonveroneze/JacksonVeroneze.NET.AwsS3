using Microsoft.Extensions.Logging;

namespace JacksonVeroneze.NET.AwsS3.Extensions;

public static partial class LogMessagesExtensions
{
    #region Common

    [LoggerMessage(
        EventId = 1000,
        Level = LogLevel.Error,
        Message = "{className} - {methodName} - Error")]
    public static partial void LogGenericError(this ILogger logger,
        string className, string methodName,
        Exception ex);

    #endregion

    #region Bucket

    [LoggerMessage(
        EventId = 2000,
        Level = LogLevel.Debug,
        Message = "{className} - {methodName} - GetPaged - Count: {count}")]
    public static partial void LogGetAllBuckets(this ILogger logger,
        string className, string methodName,
        int count);

    [LoggerMessage(
        EventId = 2001,
        Level = LogLevel.Debug,
        Message = "{className} - {methodName} - Name: '{name}' - Created")]
    public static partial void LogCreateBucket(this ILogger logger,
        string className, string methodName,
        string name);

    [LoggerMessage(
        EventId = 2002,
        Level = LogLevel.Debug,
        Message = "{className} - {methodName} - Name: '{name}' - Deleted")]
    public static partial void LogDeleteBucket(this ILogger logger,
        string className, string methodName,
        string name);

    [LoggerMessage(
        EventId = 2003,
        Level = LogLevel.Debug,
        Message = "{className} - {methodName} - Name: '{name}' - Exists: '{exists}'")]
    public static partial void LogExistsBucket(this ILogger logger,
        string className, string methodName,
        string name, bool exists);

    #endregion

    #region Object

    [LoggerMessage(
        EventId = 3000,
        Level = LogLevel.Debug,
        Message = "{className} - {methodName} - " +
                  "BucketName: '{bucketName}'- GetPaged - Count: {count}")]
    public static partial void LogGetAllObjects(this ILogger logger,
        string className, string methodName,
        string bucketName, int count);

    [LoggerMessage(
        EventId = 3001,
        Level = LogLevel.Debug,
        Message = "{className} - {methodName} - " +
                  "BucketName: '{bucketName}' - Key: '{key}' - Get")]
    public static partial void LogGetObjectBykey(this ILogger logger,
        string className, string methodName,
        string bucketName, string key);

    [LoggerMessage(
        EventId = 3002,
        Level = LogLevel.Debug,
        Message = "{className} - {methodName} - " +
                  "BucketName: '{bucketName}' - Key: '{key}' - Created")]
    public static partial void LogCreateObject(this ILogger logger,
        string className, string methodName,
        string bucketName, string key);

    [LoggerMessage(
        EventId = 3003,
        Level = LogLevel.Debug,
        Message = "{className} - {methodName} - " +
                  "BucketName: '{bucketName}' - Key: '{key}' - Deleted")]
    public static partial void LogDeleteObject(this ILogger logger,
        string className, string methodName,
        string bucketName, string key);

    #endregion
}