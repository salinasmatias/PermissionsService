using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsMS.Entities
{
    public class PermissionType
    {
        public PermissionType()
        {
            Permissions = new HashSet<Permission>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
