using PermissionsMS.Abstractions;
using PermissionsMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsMS.Repositories.Interfaces
{
    public interface IPermissionsRepository
    {
        void AddPermission(Permission permission);
        void UpdatePermission(Permission permission);
        void DeletePermission(Permission permission);
        IEnumerable<Permission> GetAllPermissionsAsync();
        Task<IEnumerable<Permission>> PaginatedGetAllPermissionsAsync(IPaginationFilter filter);
        int CountPermissions();
        Permission GetPermissionByIdAsync(int id);
    }
}
