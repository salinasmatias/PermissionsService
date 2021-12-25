using PermissionsMS.Core.DTOs;
using PermissionsMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsMS.Core.Business.Interfaces
{
    public interface IPermissionsBusiness
    {
        Permission AddPermission(PermissionDtoForCreation permission);
        Permission UpdatePermission(PermissionDtoForEdit permission);
        Permission DeletePermission(Permission permission);
        Task<IEnumerable<PermissionDtoForDisplay>> GetAllPermissionsAsync();
        Task<PermissionDtoForDisplay> GetPermissionByIdAsync(int id);
    }
}
