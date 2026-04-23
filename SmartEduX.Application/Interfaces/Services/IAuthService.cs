namespace SmartEduX.Application.Interfaces.Services;

public interface IAuthService
{
    Task<OperationResponse<ApplicationUserDto?>> SignUpAsync(SignUpDto dto, CancellationToken cancellationToken = default);

    Task<OperationResponse<ApplicationUserDto?>> SignInAsync(SignInDto dto, CancellationToken cancellationToken = default);
}
