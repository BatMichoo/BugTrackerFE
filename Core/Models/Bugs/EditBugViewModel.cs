using Core.Utilities.JsonConverters;
using Core.Utilities;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Bugs
{
    public class EditBugViewModel
    {
        [Required]
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BugStatus Status { get; set; }
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime? LastUpdatedOn { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BugPriority Priority { get; set; }

        [Required]
        public string Description { get; set; } = null!;
        public bool IsAssigned => AssignedTo != null;

        [JsonPropertyName("AssigneeId")]
        public string? AssignedTo { get; set; }
    }
}
