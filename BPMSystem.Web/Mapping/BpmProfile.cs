using System;
using AutoMapper;
using BPMSystem.BLL.DTO;
using BPMSystem.BLL.DTO.Employee;
using BPMSystem.BLL.DTO.Employees;
using BPMSystem.BLL.DTO.Position;
using BPMSystem.DAL.Entities;

namespace BPMSystem.Web.Mapping
{
    public class BpmProfile : Profile 
    {
        public BpmProfile()
        {
            //Department Mapping
            CreateMap<Department, ViewModelDepartment>();
            CreateMap<ViewModelDepartment, Department>();
            CreateMap<ViewModelCreateDepartment, Department>();

            //Position Mapping
            CreateMap<Position, ViewModelPosition>();
            CreateMap<ViewModelPosition, Position>();
            CreateMap<ViewModelCreatePosition, Position>();

            //Employee Mapping
            CreateMap<Employee, ViewModelEmployee>();
            CreateMap<ViewModelEmployee, Employee>();
            CreateMap<ViewModelCreateEmployee, Employee>()
                .ForMember(dest => dest.EditDate, opt => opt.MapFrom(src => src.EditData == DateTime.Now));
        }
    }
}
