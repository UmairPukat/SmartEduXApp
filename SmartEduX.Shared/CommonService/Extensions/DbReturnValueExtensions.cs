namespace CommonService.Extensions;

public static class DbReturnValueExtensions
{
    /// <summary>Maps a business result code to an HTTP status (for failures; success paths use 200 from the factory).</summary>
    public static int ToHttpStatusCode(this DbReturnValue code) =>
        code switch
        {
            DbReturnValue.CreateSuccess
                or DbReturnValue.UpdateSuccess
                or DbReturnValue.DeleteSuccess
                or DbReturnValue.RetrievedSuccess
                or DbReturnValue.ListRetrievedSuccess
                or DbReturnValue.SignInSuccess
                or DbReturnValue.SignUpSuccess => 200,

            DbReturnValue.NotFound
                or DbReturnValue.ProvinceNotFound
                or DbReturnValue.CityNotFound
                or DbReturnValue.TenantNotFound
                or DbReturnValue.ApplicationUserNotFound
                or DbReturnValue.ApplicationRoleNotFound => 404,

            DbReturnValue.Conflict
                or DbReturnValue.CityDeleteBlockedByTenants => 409,

            DbReturnValue.SignInInvalidCredentials => 401,

            DbReturnValue.SignInLockedOut
                or DbReturnValue.SignInNotAllowed
                or DbReturnValue.Forbidden => 403,

            DbReturnValue.InternalServerError => 500,

            _ => 400,
        };
}
