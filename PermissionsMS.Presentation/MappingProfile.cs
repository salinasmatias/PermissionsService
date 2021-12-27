using AutoMapper;
using PermissionsMS.Core.DTOs;
using PermissionsMS.Entities;

namespace PermissionsMS.Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PermissionDtoForCreation, Permission>();
            CreateMap<Permission, PermissionDtoForDisplay>();
            CreateMap<PermissionDtoForEdit, Permission>();
        }
    }
}
