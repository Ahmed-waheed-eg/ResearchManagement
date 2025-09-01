using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ResearchManage.Api.Base;
using ResearchManage.Application.Features.Research.Queries.Models;
using ResearchManage.Application.Features.Research.Queries.Respones;
using ResearchManage.Application.Features.Researchers.Queries.Models;
using ResearchManage.Application.Features.Researchers.Queries.Results;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.AppMetaData;

namespace ResearchManage.Api.Controllers
{
    [ApiController]
    public class ResearchController(IMediator _Mediator) : AppControllerBase
    {
        #region Queries Actions

        [HttpGet(MyRouter.ResearchRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NotFound<GetResearchByIdResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<GetResearchByIdResponse>))]
        public async Task<IActionResult> GetResearchByID(int id)
        {
            var response = await _Mediator.Send(new GetResearchByIdQuery(id));
            if (response.Succeeded)
            {
                return MyResult(response);
            }
            return MyResult(response);
        }


        [HttpGet(MyRouter.ResearchRouting.Paginated)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MyResponse<GetResearchPaginationResponse>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<GetResearchPaginationResponse>))]
        public async Task<IActionResult> GetScholarPaginatedList([FromQuery] GetResearchPaginationQuery queey)
        {

            var response = await _Mediator.Send(queey);

            return Ok(response);

        }

        #endregion
    }
}
