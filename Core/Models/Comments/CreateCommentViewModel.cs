namespace Core.Models.Comments
{
    public class CreateCommentViewModel
    {
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public int BugId { get; set; }
    }
}
