using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResearchManage.Api.Base;
using ResearchManage.Application.Features.Researchers.Commands.Models;
using ResearchManage.Application.Features.Researchers.Queries.Models;
using ResearchManage.Application.Features.Researchers.Queries.Results;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.AppMetaData;

namespace ResearchManage.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ScholarConteroller(IMediator _Mediator) : AppControllerBase
    {
        #region Queries Actions
        [HttpGet(MyRouter.ScholarRouting.list)]
        public async Task<IActionResult> GetScholarList()
        {

            var response = await _Mediator.Send(new GetScholarsListQuery());
            
            return MyResult(response);

        }
        [HttpGet(MyRouter.ScholarRouting.Paginated)]
        public async Task<IActionResult> GetScholarPaginatedList([FromQuery] GetScholarPaginationQuery queey)
        {

            var response = await _Mediator.Send(queey);

            return Ok(response);

        }

        [HttpGet(MyRouter.ScholarRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MyResponse<ScholarDTO>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<ScholarDTO>))]
        public async Task<IActionResult> GetScholarById(int id)
        {
            var response = await _Mediator.Send(new GetScholarByIDQuery(id));
            if (response.Succeeded)
            {
                return MyResult(response);
            }
            return MyResult(response);
        }
        #endregion





        #region Queries Actions
     
        [HttpPost(MyRouter.ScholarRouting.Create)]
        public async Task<IActionResult> Create([FromBody]AddScholarCommand command)
        {
            var response = await _Mediator.Send(command);
            return MyResult(response);
        }
        [HttpPut(MyRouter.ScholarRouting.Edite)]
        public async Task<IActionResult> Edite([FromBody] EditeScholarCommand command)
        {
            var response = await _Mediator.Send(command);
            return MyResult(response);
        }

        [HttpDelete(MyRouter.ScholarRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _Mediator.Send(new DeleteScholarCommand(id));
            if (response.Succeeded)
            {
                return MyResult(response);
            }
            return MyResult(response);
        }
        #endregion



    }
}
