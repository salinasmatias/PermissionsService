using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermissionsMS.Core.Business.Interfaces;
using PermissionsMS.Core.DTOs;
using PermissionsMS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionsMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionsBusiness _business;
        private readonly IUriService _uriService;

        public PermissionsController(IPermissionsBusiness business, IUriService uriService)
        {
            _business = business;
            _uriService = uriService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<PermissionDtoForDisplay>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTestimonials([FromQuery] PaginationFilter filter)
        {
            try
            {
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var permissions = await _business.GetAllPermissionsAsync(validFilter);
                var totalRecords = _business.CountPermissions();
                var pagedResponse = PaginationHelper.CreatePagedReponse<PermissionDtoForDisplay>(permissions.ToList(),
                                                                                                   validFilter,
                                                                                                   totalRecords,
                                                                                                   _uriService,
                                                                                                   route);

                return new JsonResult(pagedResponse) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal error");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(PermissionDtoForDisplay), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorRequestDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RequestPermission([FromBody] PermissionDtoForCreation permission)
        {
            try
            {
                var response = await _business.AddPermission(permission);

                if(response != null)
                {
                    return new JsonResult(response) { StatusCode = 201 };
                }

                return new JsonResult(new ErrorRequestDto()) { StatusCode = 400 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PermissionDtoForDisplay), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorRequestDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifyPermission(int id, [FromBody] PermissionDtoForEdit permission)
        {
            try
            {
                var response = await _business.GetPermissionByIdAsync(id);

                if (response == null)
                {
                    return NotFound();
                }

                var updateResponse = await _business.UpdatePermission(response, permission);
                if(updateResponse != null)
                {
                    return new JsonResult(permission) { StatusCode = 200 };
                }

                return new JsonResult(new ErrorRequestDto()) { StatusCode = 400 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}
