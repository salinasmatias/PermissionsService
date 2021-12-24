﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsMS.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
