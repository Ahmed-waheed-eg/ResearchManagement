using MediatR;
using ResearchManage.Application.ResponseBases;

namespace ResearchManage.Application.Features.Users.Command.Models
{
    public class CreateUserCommand : IRequest<MyResponse<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string address { get; set; } = default!;
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
