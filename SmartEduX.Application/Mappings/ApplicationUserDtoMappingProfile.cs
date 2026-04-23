namespace SmartEduX.Application.Mappings;

public class ApplicationUserDtoMappingProfile : Profile
{
    public ApplicationUserDtoMappingProfile()
    {
        CreateMap<ApplicationUser, ApplicationUserDto>();
    }
}
