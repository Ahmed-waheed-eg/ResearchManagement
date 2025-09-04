using MediatR;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Users.Command.Models
{
    public class EditUserCommand : IRequest<MyResponse<string>>
    {
        public string Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
