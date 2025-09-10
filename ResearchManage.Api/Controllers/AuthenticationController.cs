using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResearchManage.Api.Base;
using ResearchManage.Application.Features.Authentication.Commands.Models;
using ResearchManage.Domain.AppMetaData;

namespace ResearchManage.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator _Mediator) : AppControllerBase
    {
        #region Commands Actions
        [HttpPost(MyRouter.AuthenticationRouting.SignIn)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand model)
        {
            var result = await _Mediator.Send(model);
            return MyResult(result);
        }

        //[HttpPost(Router.AuthenticationRouting.RefreshToken)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand model)
        //{
        //    var result = await _mediator.Send(model);
        //    return NewResult(result);
        //}
        #endregion
    }
}
