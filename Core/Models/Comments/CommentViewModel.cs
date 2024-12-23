using Core.Utilities.JsonConverters;
using System.Text.Json.Serialization;

namespace Core.Models.Comments
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int Likes { get; set; }

        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime PostedOn { get; set; }

        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime LastUpdatedOn { get; set; }

        public int BugId { get; set; }
        public string AuthorName { get; set; } = null!;
    }
}
