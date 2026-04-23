namespace CommonService.Enums;

public enum DbReturnValue
{
    [EnumMember(Value = "Create Success")]
    [Description("The record was created successfully.")]
    CreateSuccess = 100,

    [EnumMember(Value = "Creation Failed")]
    [Description("The record could not be created.")]
    CreationFailed = 101,

    [EnumMember(Value = "Update Success")]
    [Description("The record was updated successfully.")]
    UpdateSuccess = 102,

    [EnumMember(Value = "Update Failed")]
    [Description("The record could not be updated.")]
    UpdateFailed = 103,

    [EnumMember(Value = "Delete Success")]
    [Description("The record was deleted successfully.")]
    DeleteSuccess = 104,

    [EnumMember(Value = "Delete Failed")]
    [Description("The record could not be deleted.")]
    DeleteFailed = 105,

    [EnumMember(Value = "Not Found")]
    [Description("No matching record was found.")]
    NotFound = 106,

    [EnumMember(Value = "Retrieve Success")]
    [Description("The record was retrieved successfully.")]
    RetrievedSuccess = 107,

    [EnumMember(Value = "Retrieve List Success")]
    [Description("The list was retrieved successfully.")]
    ListRetrievedSuccess = 108,

    [EnumMember(Value = "Conflict")]
    [Description("The operation could not be completed because of a conflict.")]
    Conflict = 109,

    [EnumMember(Value = "Bad Request")]
    [Description("The request was invalid or could not be processed.")]
    BadRequest = 110,

    [EnumMember(Value = "Province Not Found")]
    [Description("The requested province was not found.")]
    ProvinceNotFound = 111,

    [EnumMember(Value = "City Not Found")]
    [Description("The requested city was not found.")]
    CityNotFound = 112,

    [EnumMember(Value = "Tenant Not Found")]
    [Description("The requested tenant was not found.")]
    TenantNotFound = 113,

    [EnumMember(Value = "User Not Found")]
    [Description("The requested user was not found.")]
    ApplicationUserNotFound = 114,

    [EnumMember(Value = "Role Not Found")]
    [Description("The requested role was not found.")]
    ApplicationRoleNotFound = 115,

    [EnumMember(Value = "Referenced Province Not Found")]
    [Description("The selected province does not exist.")]
    ReferencedProvinceNotFound = 116,

    [EnumMember(Value = "City Delete Blocked")]
    [Description("This city cannot be deleted because one or more tenants still reference it.")]
    CityDeleteBlockedByTenants = 117,

    [EnumMember(Value = "Sign In Invalid")]
    [Description("The username or password is incorrect.")]
    SignInInvalidCredentials = 118,

    [EnumMember(Value = "Sign In Locked Out")]
    [Description("The account is locked. Please try again later.")]
    SignInLockedOut = 119,

    [EnumMember(Value = "Sign In Not Allowed")]
    [Description("Sign-in is not allowed for this account.")]
    SignInNotAllowed = 120,

    [EnumMember(Value = "Identity Operation Failed")]
    [Description("The account operation could not be completed.")]
    IdentityOperationFailed = 121,

    [EnumMember(Value = "Sign In Success")]
    [Description("Signed in successfully.")]
    SignInSuccess = 122,

    [EnumMember(Value = "Sign Up Success")]
    [Description("Registered and signed in successfully.")]
    SignUpSuccess = 123,

    [EnumMember(Value = "Forbidden")]
    [Description("You are not allowed to perform this operation.")]
    Forbidden = 124,

    [EnumMember(Value = "Internal Server Error")]
    [Description("An unexpected error occurred. Please try again later.")]
    InternalServerError = 500,
}
