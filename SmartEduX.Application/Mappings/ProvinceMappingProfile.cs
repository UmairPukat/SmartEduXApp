namespace SmartEduX.Application.Mappings;

public class ProvinceMappingProfile : Profile
{
    public ProvinceMappingProfile()
    {
        CreateMap<Province, ProvinceDto>();

        CreateMap<CreateProvinceDto, Province>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Cities, o => o.Ignore())
            .ForMember(d => d.Tenants, o => o.Ignore());

        CreateMap<UpdateProvinceDto, Province>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Cities, o => o.Ignore())
            .ForMember(d => d.Tenants, o => o.Ignore());
    }
}
