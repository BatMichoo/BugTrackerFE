using Core.Utilities;
using Core.Utilities.JsonConverters;
using System.Text.Json.Serialization;

namespace Presentation.Models.Bugs
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
        public string Description { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string LastUpdatedBy { get; set; } = null!;
        public bool IsAssigned { get; set; }
        public string? AssignedTo { get; set; }
    }
}