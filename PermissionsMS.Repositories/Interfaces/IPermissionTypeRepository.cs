using PermissionsMS.Abstractions;
using PermissionsMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsMS.Repositories.Interfaces
{
    public interface IPermissionTypeRepository
    {
        void AddPermissionType(PermissionType permissionType);
        void UpdatePermissionType(PermissionType permissionType);
        void DeletePermission(PermissionType permissionType);
        IEnumerable<PermissionType> GetAllPermissionTypes();
        Task<IEnumerable<PermissionType>> PaginatedGetAllPermissionTypesAsync(IPaginationFilter filter);
        int CountPermissions();
        Task<PermissionType> GetPermissionTypeByIdAsync(int id);
    }
}
