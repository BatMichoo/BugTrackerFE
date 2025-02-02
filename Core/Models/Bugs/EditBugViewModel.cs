using Core.Utilities.JsonConverters;
using Core.Utilities;
using System.Text.Json.Serialization;

namespace Core.Models.Bugs
{
    public class EditBugViewModel
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BugStatus Status { get; set; }
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime? LastUpdatedOn { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BugPriority Priority { get; set; }
        public string Description { get; set; } = null!;
        public bool IsAssigned { get; set; }

        [JsonPropertyName("AssigneeId")]
        public string? AssignedTo { get; set; }
    }
}
