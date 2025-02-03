using Core.Models.Bugs;
using Core.Models.Users;

namespace Core.Models.Endpoints
{
    public class GetBugViewModel
    {
        public BugViewModel Bug { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}
