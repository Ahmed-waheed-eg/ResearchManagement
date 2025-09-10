
using Microsoft.AspNetCore.Identity;

namespace ResearchManage.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public string address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; } = new HashSet<UserRefreshToken>();

        public User()
        {

        }
        public User(string firstName, string lastName)
        {
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }
    }
}
