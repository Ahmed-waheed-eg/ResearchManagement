using Microsoft.Extensions.Localization;
using ResearchManage.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.ResponseBases
{
    public class MyResponseHandler
    {

        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public MyResponseHandler(IStringLocalizer<SharedResources> stringLocalizer)
            {
            _stringLocalizer = stringLocalizer;
            }
            public MyResponse<T> Deleted<T>()
            {
            return new MyResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKeys.Deleted]
            };
            }
            public MyResponse<T> Success<T>(T entity, object Meta = null)
            {
                return new MyResponse<T>()
                {
                    Data = entity,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Succeeded = true,
                    Message = _stringLocalizer[SharedResourcesKeys.Success],
                    Meta = Meta
                };
            }
            public MyResponse<T> Unauthorized<T>()
            {
                return new MyResponse<T>()
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    Succeeded = true,
                    Message = "UnAuthorized"
                };
            }
            public MyResponse<T> BadRequest<T>(string Message = null)
            {
                return new MyResponse<T>()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Succeeded = false,
                    Message = Message == null ? "Bad Request" : Message
                };
            }

        public MyResponse<T> UnprocessableEntity<T>(string Message = null)
        {
            return new MyResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = Message == null ? "Unprocessable Entity" : Message
            };
        }
        public MyResponse<T> NotFound<T>(string message = null)
            {
                return new MyResponse<T>()
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Succeeded = false,
                    Message = message == null ? _stringLocalizer[SharedResourcesKeys.NotFound] : message
                };
            }

            public MyResponse<T> Created<T>(T entity, object Meta = null)
            {
                return new MyResponse<T>()
                {
                    Data = entity,
                    StatusCode = System.Net.HttpStatusCode.Created,
                    Succeeded = true,
                    Message = _stringLocalizer[SharedResourcesKeys.Created],
                    Meta = Meta
                };
            }
    }
    
}
