namespace CommonService.Dtos;

public class OperationResponse<T>
{
    public bool HasSucceeded { get; set; }

    /// <summary>HTTP-style status (200, 400, 401, 403, 404, 409).</summary>
    public int StatusCode { get; set; }

    /// <summary>Application / business code (same integer as <c>DbReturnValue</c>).</summary>
    public int ResultCode { get; set; }

    /// <summary>User-facing outcome text (from enum description unless overridden).</summary>
    public string Message { get; set; } = string.Empty;

    public T? Result { get; set; }

    /// <summary>Server-only metadata (not serialized). Anonymous types here can break JSON output across assemblies.</summary>
    [JsonIgnore]
    public string? CreatedAtAction { get; set; }

    [JsonIgnore]
    public object? CreatedRouteValues { get; set; }

    public OperationResponse()
    {
    }

    /// <param name="resultCode">Cast from <c>DbReturnValue</c> (legacy 4-arg ctor).</param>
    public OperationResponse(bool hasSucceeded, int resultCode, string message, T? result)
    {
        HasSucceeded = hasSucceeded;
        ResultCode = resultCode;
        StatusCode = hasSucceeded
            ? 200
            : ((DbReturnValue)resultCode).ToHttpStatusCode();
        Message = message;
        Result = result;
    }

    public static OperationResponse<T> Success(DbReturnValue code, T result, string? message = null)
    {
        return new OperationResponse<T>
        {
            HasSucceeded = true,
            StatusCode = code.ToHttpStatusCode(),
            ResultCode = (int)code,
            Message = message ?? code.GetDescription(),
            Result = result,
        };
    }

    public static OperationResponse<T> Failure(DbReturnValue code, string? message = null, T? result = default)
    {
        return new OperationResponse<T>
        {
            HasSucceeded = false,
            StatusCode = code.ToHttpStatusCode(),
            ResultCode = (int)code,
            Message = message ?? code.GetDescription(),
            Result = result,
        };
    }
}

public class OperationResponse : OperationResponse<object>
{
    public OperationResponse()
    {
    }

    public OperationResponse(bool hasSucceeded, int resultCode, string message, object? result)
        : base(hasSucceeded, resultCode, message, result)
    {
    }

    public static OperationResponse Success(DbReturnValue code, object? result, string? message = null)
    {
        return new OperationResponse
        {
            HasSucceeded = true,
            StatusCode = code.ToHttpStatusCode(),
            ResultCode = (int)code,
            Message = message ?? code.GetDescription(),
            Result = result,
        };
    }

    public static OperationResponse Failure(DbReturnValue code, string? message = null, object? result = null)
    {
        return new OperationResponse
        {
            HasSucceeded = false,
            StatusCode = code.ToHttpStatusCode(),
            ResultCode = (int)code,
            Message = message ?? code.GetDescription(),
            Result = result,
        };
    }
}
