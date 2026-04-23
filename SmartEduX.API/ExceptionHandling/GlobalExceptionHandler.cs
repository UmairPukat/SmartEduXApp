namespace SmartEduX.API.ExceptionHandling;

/// <summary>
/// Converts any unhandled exception into the standard <see cref="OperationResponse"/> JSON
/// (same shape as controller actions) and sets the HTTP status from <see cref="DbReturnValue"/> rules.
/// </summary>
public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private const string EfCoreDbUpdateExceptionTypeName = "Microsoft.EntityFrameworkCore.DbUpdateException";
    private const int MaxDevelopmentMessageLength = 2000;

    private static readonly JsonSerializerOptions JsonOptions = CreateJsonOptions();

    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IHostEnvironment _environment;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);

        if (httpContext.Response.HasStarted)
        {
            return false;
        }

        var mapping = MapException(exception, includeTechnicalDetail: _environment.IsDevelopment());
        var payload = OperationResponse.Failure(mapping.Code, mapping.ClientMessage);

        await WriteJsonAsync(httpContext, payload, cancellationToken);
        return true;
    }

    private static JsonSerializerOptions CreateJsonOptions() =>
        new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        };

    private static async Task WriteJsonAsync(
        HttpContext httpContext,
        OperationResponse payload,
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = payload.StatusCode;
        httpContext.Response.ContentType = "application/json; charset=utf-8";

        await JsonSerializer.SerializeAsync(
            httpContext.Response.Body,
            payload,
            JsonOptions,
            cancellationToken);
    }

    /// <summary>Picks a <see cref="DbReturnValue"/> and optional message override (development only).</summary>
    private static ExceptionMapping MapException(Exception exception, bool includeTechnicalDetail)
    {
        var detail = includeTechnicalDetail ? SanitizeExceptionMessage(exception) : null;

        if (exception is ArgumentNullException or ArgumentOutOfRangeException or ArgumentException)
        {
            return new ExceptionMapping(DbReturnValue.BadRequest, detail);
        }

        if (exception is UnauthorizedAccessException)
        {
            return new ExceptionMapping(DbReturnValue.Forbidden, detail);
        }

        if (exception is KeyNotFoundException)
        {
            return new ExceptionMapping(DbReturnValue.NotFound, detail);
        }

        if (exception is InvalidOperationException or NotImplementedException)
        {
            return new ExceptionMapping(DbReturnValue.BadRequest, detail);
        }

        if (exception is TimeoutException)
        {
            return new ExceptionMapping(DbReturnValue.InternalServerError, detail);
        }

        if (IsEntityFrameworkDbUpdateException(exception))
        {
            return new ExceptionMapping(DbReturnValue.InternalServerError, detail);
        }

        return new ExceptionMapping(DbReturnValue.InternalServerError, detail);
    }

    private static bool IsEntityFrameworkDbUpdateException(Exception exception) =>
        exception.GetType().FullName?.StartsWith(EfCoreDbUpdateExceptionTypeName, StringComparison.Ordinal) == true;

    private static string? SanitizeExceptionMessage(Exception exception)
    {
        var text = string.IsNullOrWhiteSpace(exception.Message)
            ? exception.GetType().Name
            : exception.Message.Trim();

        if (text.Length > MaxDevelopmentMessageLength)
        {
            return text[..MaxDevelopmentMessageLength] + "…";
        }

        return text;
    }

    private readonly record struct ExceptionMapping(DbReturnValue Code, string? ClientMessage);
}
