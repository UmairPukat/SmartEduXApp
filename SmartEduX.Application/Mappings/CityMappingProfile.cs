namespace SmartEduX.Application.Mappings;

public class CityMappingProfile : Profile
{
    public CityMappingProfile()
    {
        CreateMap<City, CityDto>();

        CreateMap<CreateCityDto, City>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Province, o => o.Ignore())
            .ForMember(d => d.Tenants, o => o.Ignore());

        CreateMap<UpdateCityDto, City>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Province, o => o.Ignore())
            .ForMember(d => d.Tenants, o => o.Ignore());
    }
}
