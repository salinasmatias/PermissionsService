using AutoMapper;
using PermissionsMS.Core.DTOs;
using PermissionsMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
