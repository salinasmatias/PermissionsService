using Microsoft.EntityFrameworkCore;
using PermissionsMS.Abstractions;
using PermissionsMS.DataAccess;
using PermissionsMS.Entities;
using PermissionsMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsMS.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly PermissionsContext _context;

        public PermissionsRepository(PermissionsContext context)
        {
            _context = context;
        }
        public void AddPermission(Permission permission)
        {
            _context.Permissions.Add(permission);
            _context.SaveChanges();
        }

        public int CountPermissions()
        {
            return _context.Permissions.Count();
        }

        public void DeletePermission(Permission permission)
        {
            _context.Permissions.Remove(permission);
            _context.SaveChanges();
        }

        public IEnumerable<Permission> GetAllPermissionsAsync()
        {
            return _context.Permissions;
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _context.Permissions.FindAsync(id);
        }

        public async Task<IEnumerable<Permission>> PaginatedGetAllPermissionsAsync(IPaginationFilter filter)
        {
            return await _context.Permissions.Skip((filter.PageNumber - 1) * filter.PageSize)
                               .Take(filter.PageSize)
                               .ToListAsync();
        }

        public void UpdatePermission(Permission permission)
        {
            _context.Permissions.Update(permission);
            _context.SaveChanges();
        }
    }
}
