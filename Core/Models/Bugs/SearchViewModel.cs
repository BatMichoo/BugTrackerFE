using Core.Utilities;
using Presentation.ModelValidations;

namespace Core.Models.Bugs
{
    [AtLeastOnePropertyRequired]
    public class SearchViewModel
    {
        public int? Id { get; set; } = null;
        public BugPriority? Priority { get; set; } = null;
        public BugStatus? Status { get; set; } = null;
        public string? AssignedTo { get; set; } = null;
        public string? Title { get; set; } = null;
    }
}
