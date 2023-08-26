using AutoMapper;
using Portal.Services.DataAPI.Model;
using Portal.Services.DataAPI.Model.ViewModel;

namespace Portal.Services.DataAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        MapperConfiguration mapper = new(config =>
        {
            config.CreateMap<DepartmentVM, Department>();
            config.CreateMap<Department, DepartmentVM>();
        });
        return mapper;
    }
}
