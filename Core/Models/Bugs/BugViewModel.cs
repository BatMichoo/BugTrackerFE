using Core.Models.Comments;
using Core.Models.Users;
using Core.Utilities;
using Core.Utilities.JsonConverters;
using System.Text.Json.Serialization;

namespace Core.Models.Bugs
{
    public class BugViewModel
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime CreatedOn { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BugStatus Status { get; set; }
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime LastUpdatedOn { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BugPriority Priority { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public UserViewModel CreatedBy { get; set; } = null!;
        public UserViewModel LastUpdatedBy { get; set; } = null!;
        public bool IsAssigned => AssignedTo != null;
        public UserViewModel AssignedTo { get; set; } = new UserViewModel();

        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
    }
}