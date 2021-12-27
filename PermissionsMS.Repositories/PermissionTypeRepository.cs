using Microsoft.EntityFrameworkCore;
using PermissionsMS.Abstractions;
using PermissionsMS.DataAccess;
using PermissionsMS.Entities;
using PermissionsMS.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionsMS.Repositories
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly PermissionsContext _context;

        public PermissionTypeRepository(PermissionsContext context)
        {
            _context = context;
        }
        public void AddPermissionType(PermissionType permissionType)
        {
            _context.PermissionTypes.Add(permissionType);
            _context.SaveChanges();
        }

        public int CountPermissions()
        {
            return _context.PermissionTypes.Count();
        }

        public void DeletePermission(PermissionType permissionType)
        {
            _context.Remove(permissionType);
            _context.SaveChanges();
        }

        public IEnumerable<PermissionType> GetAllPermissionTypes()
        {
            return _context.PermissionTypes;
        }

        public async Task<PermissionType> GetPermissionTypeByIdAsync(int id)
        {
            return await _context.PermissionTypes.FindAsync(id);
        }

        public async Task<IEnumerable<PermissionType>> PaginatedGetAllPermissionTypesAsync(IPaginationFilter filter)
        {
            return await _context.PermissionTypes.Skip((filter.PageNumber - 1) * filter.PageSize)
                               .Take(filter.PageSize)
                               .ToListAsync();
        }

        public void UpdatePermissionType(PermissionType permissionType)
        {
            _context.PermissionTypes.Update(permissionType);
            _context.SaveChanges();
        }
    }
}
