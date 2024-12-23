using Core.Models.Bugs;
using Core.Models.Bugs.Create;

namespace Core.Services
{
    public class MappingService
    {
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
