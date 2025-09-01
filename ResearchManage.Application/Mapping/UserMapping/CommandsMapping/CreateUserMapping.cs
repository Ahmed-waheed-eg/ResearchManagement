using ResearchManage.Application.Features.Users.Command.Models;
using ResearchManage.Domain.Entities.Identity;

namespace ResearchManage.Application.Mapping.UserMapping
{
    public partial class UserProfil
    {


        public void CreateUserMapping()
        {
            CreateMap<CreateUserCommand, User>()
           .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName))
           .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName))
           .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber))
           .ForMember(x => x.address, opt => opt.MapFrom(x => x.address));


        }


    }

}
