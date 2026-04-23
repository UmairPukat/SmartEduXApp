namespace SmartEduX.Application.Mappings;

public class ApplicationRoleDtoMappingProfile : Profile
{
    public ApplicationRoleDtoMappingProfile()
    {
        CreateMap<ApplicationRole, ApplicationRoleDto>();
    }
}
