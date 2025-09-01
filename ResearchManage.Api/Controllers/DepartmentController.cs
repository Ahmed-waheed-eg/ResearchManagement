using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResearchManage.Api.Base;
using ResearchManage.Application.Features.Department.Queries.Models;
using ResearchManage.Application.Features.Department.Queries.Respones;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.AppMetaData;

namespace ResearchManage.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IMediator _Mediator) : AppControllerBase
    {

        #region Queries Actions



        //paginatio department
        [HttpGet(MyRouter.DepartmentRouting.Paginated)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<GetAllDepartmentPaginationResnose>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MyResponse<GetAllDepartmentPaginationResnose>))]
        public async Task<IActionResult> GetDepartmentPaginatedList([FromQuery] GetAllDepartmentPaginationQuery queey)
        {
            var response = await _Mediator.Send(queey);
            return Ok(response);
        }

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


        [HttpGet(MyRouter.DepartmentRouting.Research)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<GetDepartmentByIdWithResearchesRespone>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MyResponse<GetDepartmentByIdWithResearchesRespone>))]
        public async Task<IActionResult> GetDepartmentWithResearchesPaginatedList([FromQuery] GetDepartmentByIdWithResearchesQuery queey)
        {

            var response = await _Mediator.Send(queey);

            return Ok(response);

        }

        #endregion
    }
}
