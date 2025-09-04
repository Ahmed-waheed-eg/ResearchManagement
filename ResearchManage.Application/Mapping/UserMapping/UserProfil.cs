using AutoMapper;

namespace ResearchManage.Application.Mapping.UserMapping
{
    public partial class UserProfil : Profile
    {
        public UserProfil()
        {

            CreateUserMapping();
            EditeUserMapping();

        }
    }

}
