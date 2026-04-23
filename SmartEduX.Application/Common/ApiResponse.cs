namespace SmartEduX.Application.Common;

/// <summary>Short helpers for common outcomes so services stay easy to scan.</summary>
public static class ApiResponse
{
    public static OperationResponse<T?> NotFound<T>(DbReturnValue code = DbReturnValue.NotFound) =>
        OperationResponse<T?>.Failure(code);

    public static OperationResponse<T?> Fail<T>(DbReturnValue code, string? message = null) =>
        OperationResponse<T?>.Failure(code, message);

    public static OperationResponse<T?> BadRequest<T>(string message) =>
        OperationResponse<T?>.Failure(DbReturnValue.BadRequest, message);

    /// <summary>Identity validation: enum message plus joined error lines.</summary>
    public static OperationResponse<T?> BadRequest<T>(IEnumerable<string> errorDescriptions)
    {
        var details = string.Join(" ", errorDescriptions);
        var summary = DbReturnValue.IdentityOperationFailed.GetDescription();
        var message = string.IsNullOrWhiteSpace(details) ? summary : $"{summary} {details}";
        return OperationResponse<T?>.Failure(DbReturnValue.IdentityOperationFailed, message);
    }

    public static OperationResponse<T?> Conflict<T>(string message) =>
        OperationResponse<T?>.Failure(DbReturnValue.Conflict, message);

    public static OperationResponse<T?> Conflict<T>(DbReturnValue code, string? message = null) =>
        OperationResponse<T?>.Failure(code, message);

    public static OperationResponse<T?> Ok<T>(DbReturnValue code, T? data) =>
        OperationResponse<T?>.Success(code, data);

    /// <summary>Success with no <c>Result</c> payload (avoids generic inference issues when passing <c>null</c>).</summary>
    public static OperationResponse<T?> OkEmpty<T>(DbReturnValue code) =>
        OperationResponse<T?>.Success(code, default);
}
