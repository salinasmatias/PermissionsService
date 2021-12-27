using System.ComponentModel.DataAnnotations;

namespace PermissionsMS.Core.DTOs
{
    public class PermissionDtoForCreation
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string EmployeeForename { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string EmployeeSurname { get; set; }

        [Required]
        public int PermissionTypeId { get; set; }
    }
}
