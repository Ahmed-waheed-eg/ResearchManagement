using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ResearchManage.Api.Base;
using ResearchManage.Application.Features.Users.Command.Models;
using ResearchManage.Application.Features.Users.Queries.Models;
using ResearchManage.Application.Features.Users.Queries.Results;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.AppMetaData;

namespace ResearchManage.Api.Controllers
{

    [ApiController]
    public class UsersController(IMediator _Mediator) : AppControllerBase
    {
        #region Queries Actions

        [HttpGet(MyRouter.User.list)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(NotFound<string>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<string>))]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var response = await _Mediator.Send(new GetAllUsersQuery());
            if (response.Succeeded)
            {
                return MyResult(response);
            }
            return MyResult(response);
        }

        [HttpGet(MyRouter.User.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<GetUserByIdResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MyResponse<GetUserByIdResponse>))]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var result = await _Mediator.Send(new GetUserByIdQuery() { Id = id });
            return MyResult(result);
        }


        #endregion

        #region Command Actions


        [HttpPost(MyRouter.User.Create)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyResponse<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MyResponse<string>))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand model)
        {
            var result = await _Mediator.Send(model);
            return MyResult(result);
        }


        #endregion
    }
}
