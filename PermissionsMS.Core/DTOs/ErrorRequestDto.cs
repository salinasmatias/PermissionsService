using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsMS.Core.DTOs
{
    public class ErrorRequestDto
    {
        public string Message { get; set; }

        public ErrorRequestDto()
        {
            Message = "An error occurred while creating the permission request. Make sure the body of the request is properly formatted and that" +
                "the submitted PermissionTypeId is valid";
        }
    }
}
