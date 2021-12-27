using PermissionsMS.Abstractions;
using PermissionsMS.Core.DTOs;
using PermissionsMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionsMS.Core.Business.Interfaces
{
    public interface IPermissionsBusiness
    {
        Task<PermissionDtoForDisplay> AddPermission(PermissionDtoForCreation permission);
        Task<Permission> UpdatePermission(Permission permission, PermissionDtoForEdit permissionDto);
        Permission DeletePermission(Permission permission);
        Task<IEnumerable<PermissionDtoForDisplay>> GetAllPermissionsAsync(IPaginationFilter filter);
        int CountPermissions();
        Task<Permission> GetPermissionByIdAsync(int id);
    }
}
