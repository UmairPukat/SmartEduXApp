using System.Security.Claims;

namespace SmartEduX.API.Middleware;

public sealed class TokenClaimsMiddleware
{
    private readonly RequestDelegate _next;

    public TokenClaimsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var user = context.User;

        if (user?.Identity?.IsAuthenticated != true)
        {
            await _next(context);
            return;
        }

        var name = GetClaim(user, ClaimTypes.Name, "name", "unique_name");
        var email = GetClaim(user, ClaimTypes.Email, "email", "preferred_username");
        var userId = GetClaim(user, ClaimTypes.NameIdentifier, "sub", "oid");

        var role = GetClaim(user, ClaimTypes.Role, "role", "Role");

        if (!string.IsNullOrEmpty(name))
        {
            context.Request.Headers["Name"] = name;
        }

        if (!string.IsNullOrEmpty(email))
        {
            context.Request.Headers["Email"] = email;
        }

        if (!string.IsNullOrEmpty(userId))
        {
            context.Request.Headers["UserId"] = userId;
        }

        if (!string.IsNullOrEmpty(role))
        {
            context.Request.Headers["Role"] = role;
        }

        await _next(context);
    }

    private static string? GetClaim(ClaimsPrincipal user, params string[] types)
    {
        foreach (var type in types)
        {
            var value = user.Claims.FirstOrDefault(c => c.Type == type)?.Value;
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
        }

        return null;
    }
}
