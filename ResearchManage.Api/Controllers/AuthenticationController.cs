using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResearchManage.Api.Base;
using ResearchManage.Application.Features.Authentication.Commands.Models;
using ResearchManage.Application.Features.Authentication.Queries.Models;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.AppMetaData;
using ResearchManage.Domain.Helpers;

namespace ResearchManage.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator _Mediator) : AppControllerBase
    {

        [HttpGet(MyRouter.AuthenticationRouting.ValidateToken)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MyResponse<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateToken([FromQuery] GetAccessTokenValidityQuery model)
        {
            var result = await _Mediator.Send(model);
            return MyResult(result);
        }


        #region Commands Actions
        [HttpPost(MyRouter.AuthenticationRouting.SignIn)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MyResponse<JwtAuthTokenResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand model)
        {
            var result = await _Mediator.Send(model);
            return MyResult(result);
        }

        [HttpPost(MyRouter.AuthenticationRouting.RefreshToken)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MyResponse<JwtAuthTokenResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand model)
        {
            var result = await _Mediator.Send(model);
            return MyResult(result);
        }
        #endregion
    }
}
