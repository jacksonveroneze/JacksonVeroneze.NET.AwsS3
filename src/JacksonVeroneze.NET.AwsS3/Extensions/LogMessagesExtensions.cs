using Microsoft.Extensions.Logging;

namespace JacksonVeroneze.NET.AwsS3.Extensions;

public static partial class LogMessagesExtensions
{
    #region Common

    #endregion

    #region Bucket

    [LoggerMessage(
        EventId = 2000,
        Level = LogLevel.Debug,
        Message = "{className} - {methodName} - GetPaged - Count: {count}")]
    public static partial void LogGetAll(this ILogger logger,
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
}