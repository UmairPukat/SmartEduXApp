namespace SmartEduX.Application.Mappings;

public class TenantMappingProfile : Profile
{
    public TenantMappingProfile()
    {
        CreateMap<Tenant, TenantDto>();

        CreateMap<CreateTenantDto, Tenant>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.CreatedDate, o => o.Ignore())
            .ForMember(d => d.Province, o => o.Ignore())
            .ForMember(d => d.City, o => o.Ignore());

        CreateMap<UpdateTenantDto, Tenant>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.CreatedDate, o => o.Ignore())
            .ForMember(d => d.Province, o => o.Ignore())
            .ForMember(d => d.City, o => o.Ignore());
    }
}
