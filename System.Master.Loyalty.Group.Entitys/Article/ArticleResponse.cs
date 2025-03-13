namespace System.Master.Loyalty.Group.Entities.Article
{
    public class ArticleResponse
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ImageName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
