using System;
using System.Linq;
using AutoMapper;
using BPMSystem.DAL.Entities;
using BPMSystem.Web.ViewModel;

namespace BPMSystem.Web.Mapping
{
    public class BpmProfile : Profile 
    {
        public BpmProfile()
        {
            //Department Mapping
            CreateMap<Department, ViewModelDepartment>()
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
            CreateMap<ViewModelDepartment, Department>();
            CreateMap<ViewModelCreateDepartment, Department>();

            //Position Mapping
            CreateMap<Position, ViewModelPosition>();
            CreateMap<ViewModelPosition, Position>();
            CreateMap<ViewModelCreatePosition, Position>();

            //Employee Mapping
            CreateMap<Employee, ViewModelEmployee>()
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.EditDate, opt => opt.MapFrom(src => src.EditDate.HasValue ? src.EditDate.Value.ToString("dd.MM.yyyy")
                                                                                                  : string.Empty));
            CreateMap<ViewModelEmployee, Employee>();
            CreateMap<ViewModelCreateEmployee, Employee>()
                .ForMember(dest => dest.EditDate, opt => opt.MapFrom(src => src.EditData.Value));
        }
    }
}
