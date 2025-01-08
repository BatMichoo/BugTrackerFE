using Core.Utilities;

namespace Core.Models.Bugs
{
    public class SearchViewModel
    {
        public int? Id { get; set; }
        public BugPriority? Priority { get; set; }
        public BugStatus? Status { get; set; }
        public string? AssignedTo { get; set; }
        public string? Title { get; set; }
    }
}
