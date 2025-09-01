using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ResearchManage.Api.Base;
using ResearchManage.Application.Features.Supervisor.Queries.Models;
using ResearchManage.Application.Features.Supervisor.Queries.Respones;
using ResearchManage.Application.Pagination;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.AppMetaData;

namespace ResearchManage.Api.Controllers
{

    [ApiController]
    public class SupervisorController(IMediator _Mediator) : AppControllerBase
    {
        #region Queries Actions

        [HttpGet(MyRouter.Supervisor.GetById)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NotFound<GetSuoervisorByIdRespons>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<GetSuoervisorByIdRespons>))]
        public async Task<IActionResult> GetResearchByID(int id)
        {
            var response = await _Mediator.Send(new GetSuoervisorByIdQuery(id));
            if (response.Succeeded)
            {
                return MyResult(response);
            }
            return MyResult(response);
        }


        [HttpGet(MyRouter.Supervisor.Paginated)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PaginatedList<GetSupervisorPaginationResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedList<GetSupervisorPaginationResponse>))]
        public async Task<IActionResult> GetScholarPaginatedList([FromQuery] GetSupervisorPaginationQuery queey)
        {

            var response = await _Mediator.Send(queey);

            return Ok(response);

        }

        #endregion
    }
}
