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
        public void AddPermission(Permission permission)
        {
            _context.Permissions.Add(permission);
            _context.SaveChanges();
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

        public Permission GetPermissionByIdAsync(int id)
        {
            return _context.Permissions.Find(id);
        }

        public void UpdatePermission(Permission permission)
        {
            _context.Permissions.Update(permission);
            _context.SaveChanges();
        }
    }
}
