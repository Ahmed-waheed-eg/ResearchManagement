using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Api.Base
{
    [ApiController]
    public class AppControllerBase : ControllerBase
    {

        public ObjectResult MyResult<T>(MyResponse<T> myResponse)
        {
            switch (myResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(myResponse);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty,myResponse);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(myResponse);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(myResponse);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(myResponse);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty,myResponse);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult (myResponse);
                default:
                    return new BadRequestObjectResult(myResponse);

            }
        }
    }
}
