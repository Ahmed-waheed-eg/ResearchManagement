using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResearchManage.Api.Base;
using ResearchManage.Application.Features.Department.Queries.Models;
using ResearchManage.Application.Features.Department.Queries.Respones;
using ResearchManage.Application.Features.Researchers.Queries.Models;
using ResearchManage.Application.Features.Researchers.Queries.Results;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.AppMetaData;

namespace ResearchManage.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IMediator _Mediator) : AppControllerBase
    {

        #region Queries Actions

        [HttpGet(MyRouter.DepartmentRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MyResponse<GetDepartmentByIdResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<GetDepartmentByIdResponse>))]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var response = await _Mediator.Send(new GetDepartmentByIdQuery(id));
            if (response.Succeeded)
            {
                return MyResult(response);
            }
            return MyResult(response);
        }


        [HttpGet(MyRouter.DepartmentRouting.Scholars)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<GetDepartmentByIdWithScholarsResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MyResponse<GetDepartmentByIdWithScholarsResponse>))]

        public async Task<IActionResult> GetDepartmentWithScholarPaginatedList([FromQuery] GetDepartmentByIdWithScholarsQuery queey)
        {

            var response = await _Mediator.Send(queey);

            return Ok(response);

        }

        [HttpGet(MyRouter.DepartmentRouting.Supervisor)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<GetDepartmentByIdWithSupervisorRespone>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MyResponse<GetDepartmentByIdWithSupervisorRespone>))]

        public async Task<IActionResult> GetDepartmentWithSupervisorPaginatedList([FromQuery] GetDepartmentByIdWithSupervisorQuery queey)
        {

            var response = await _Mediator.Send(queey);

            return Ok(response);

        }

        #endregion
    }
}
