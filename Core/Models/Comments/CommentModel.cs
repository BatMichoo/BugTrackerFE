namespace Core.Models.Comments
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public int BugId { get; set; }
        public static CommentModel MapFrom(CreateCommentViewModel model)
        {
            return new CommentModel()
            {
                Content = model.Content,
                AuthorId = model.AuthorId,
                BugId = model.BugId
            };
        }
    }
}
