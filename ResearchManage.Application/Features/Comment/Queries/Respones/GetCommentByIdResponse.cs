namespace ResearchManage.Application.Features.Comment.Queries.Respones
{
    public class GetCommentByIdResponse
    {
        public int Id { get; set; }

        public int ResearchId { get; set; }

        public int ReviewerId { get; set; }
        public string reviewerName { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime dateTime { get; set; }
    }
}
