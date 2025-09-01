using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using ResearchManage.Application.Features.Researchers.Commands.Models;
using ResearchManage.Application.ResponseBases;
using ResearchManage.Domain.Entities;
using ResearchManage.Domain.Resources;
using ResearchManage.Services.Abstarcts;

namespace ResearchManage.Application.Features.Researchers.Commands.Handlers
{
    public class AddResearcherCommandHandler : MyResponseHandler,
        IRequestHandler<AddScholarCommand, MyResponse<string>>,
        IRequestHandler<EditeScholarCommand, MyResponse<string>>,
        IRequestHandler<DeleteScholarCommand, MyResponse<string>>

    {
        #region Fileds
        private readonly IScholarServices _ScholarServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public AddResearcherCommandHandler(IScholarServices scholarServices, IMapper mapper, IStringLocalizer<SharedResources> stringLoc) : base(stringLoc)
        {

            _ScholarServices = scholarServices;
            _stringLocalizer = stringLoc;
            _mapper = mapper;

        }

        #endregion

        #region Handle Functions

        public async Task<MyResponse<string>> Handle(AddScholarCommand request, CancellationToken cancellationToken)
        {
            var scholarmapper = _mapper.Map<Scholar>(request);

            var result = await _ScholarServices.AddAsync(scholarmapper);


            if (result == "Success") return Created("");

            return BadRequest<string>();
        }

        public async Task<MyResponse<string>> Handle(EditeScholarCommand request, CancellationToken cancellationToken)
        {
            var ScholarExist = await _ScholarServices.GetByIdAsync(request.Id);
            if (ScholarExist == null) return NotFound<string>("this id not exist");

            var scholarMapper = _mapper.Map(request, ScholarExist);

            var result = await _ScholarServices.EditeAsync(scholarMapper);

            if (result == "Success") return Success($"Edite Successfuly {scholarMapper.ID}");

            return BadRequest<string>();
        }

        public async Task<MyResponse<string>> Handle(DeleteScholarCommand request, CancellationToken cancellationToken)
        {
            var ScholarExist = await _ScholarServices.GetByIdAsync(request.Id);
            if (ScholarExist == null) return NotFound<string>("this id not exist");
            var result = await _ScholarServices.DeleteAsync(ScholarExist);
            if (result == "Success") return Deleted<string>();

            return BadRequest<string>();

        }
        #endregion
    }
}
