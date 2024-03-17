using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVC_BL.ViewModels;
using MVC_DAL.Models;

namespace MVC_BL.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee , EmployeeViewModel>().ReverseMap();
            CreateMap<Department , DepartmentViewModel>().ReverseMap();
            CreateMap<AccountUser ,UserViewModel>().ReverseMap();
            CreateMap<IdentityRole,RoleViewModel>()
                .ForMember(d=>d.RoleName ,o=>o.MapFrom(s=>s.Name))
                .ReverseMap();
        }
    }
}
