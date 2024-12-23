using Core.Utilities;

namespace Core.Models.Bugs.Create
{
    public class CreateBugModel
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public BugPriority Priority { get; set; }

        public string? AssignedTo { get; set; }

        public static CreateBugModel MapFrom(CreateBugViewModel model)
            => new CreateBugModel
            {
                Title = model.Title,
                Description = model.Description,
                Priority = model.Priority,
                AssignedTo = model.AssignedTo
            };
    }    
}
