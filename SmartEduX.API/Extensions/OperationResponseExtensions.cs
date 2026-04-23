namespace SmartEduX.API.Extensions;

public static class OperationResponseExtensions
{
    /// <summary>JSON includes <c>statusCode</c> (HTTP), <c>resultCode</c> (business), <c>message</c>; response status line matches <c>statusCode</c>.</summary>
    public static IActionResult ToApiResult<T>(this OperationResponse<T> response) =>
        new ObjectResult(response) { StatusCode = response.StatusCode };
}
