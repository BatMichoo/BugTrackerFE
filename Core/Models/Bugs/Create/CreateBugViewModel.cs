using Core.Models.Users;
using Core.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Bugs.Create
{
    public class CreateBugViewModel
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public BugPriority Priority { get; set; }

        public string? AssignedTo { get; set; }

        public List<UserViewModel>? Users { get; set; }
    }
}
