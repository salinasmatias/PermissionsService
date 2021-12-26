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
                var testimonials = await _business.GetAllPermissionsAsync(validFilter);
                var totalRecords = _business.CountPermissions();
                var pagedResponse = PaginationHelper.CreatePagedReponse<PermissionDtoForDisplay>(testimonials.ToList(),
                                                                                                   validFilter,
                                                                                                   totalRecords,
                                                                                                   _uriService,
                                                                                                   route);

                return new JsonResult(pagedResponse) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return StatusCode(500, "Internal error");
            }
        }
    }
}
