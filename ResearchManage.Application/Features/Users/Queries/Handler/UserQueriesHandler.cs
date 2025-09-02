using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Users.Queries.Models;
using ResearchManage.Application.Features.Users.Queries.Results;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Entities.Identity;
using ResearchManage.Domain.Resources;

namespace ResearchManage.Application.Features.Users.Queries.Handler
{
    public class UserQueriesHandler : MyResponseHandler,
      IRequestHandler<GetAllUsersQuery, MyResponse<List<GetAllUsersResponse>>>,
               IRequestHandler<GetUserByIdQuery, MyResponse<GetUserByIdResponse>>

    {
        #region Fileds
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public UserQueriesHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> stringLoca) : base(stringLoca)
        {
            _mapper = mapper;
            _stringLocalizer = stringLoca;
            _userManager = userManager;

        }

        #endregion


        public async Task<MyResponse<List<GetAllUsersResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersList = await _userManager.Users.Select(u => new GetAllUsersResponse
            {
                Id = u.Id,
                FullName = u.FirstName + " " + u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                UserName = u.UserName
            }).ToListAsync();

            return Success(usersList);
        }

        public async Task<MyResponse<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userMappedIntoResponse = await _userManager.Users.Where(u => u.Id == request.Id)
        .Select(u => new GetUserByIdResponse
        {
            FullName = u.FirstName + " " + u.LastName,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            UserName = u.UserName
        }).FirstOrDefaultAsync();

            if (userMappedIntoResponse is null)
                return NotFound<GetUserByIdResponse>(SharedResourcesKeys.NotFound);

            return Success(userMappedIntoResponse);
        }
    }
}
