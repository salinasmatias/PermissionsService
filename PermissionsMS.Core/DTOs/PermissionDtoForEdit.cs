using System.ComponentModel.DataAnnotations;

namespace PermissionsMS.Core.DTOs
{
    public class PermissionDtoForEdit
    {
        [StringLength(255, MinimumLength = 2)]
        public string EmployeeForename { get; set; }

        [StringLength(255, MinimumLength = 2)]
        public string EmployeeSurname { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
