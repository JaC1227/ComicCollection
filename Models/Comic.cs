namespace ComicCollection.Models
{
    public class Comic
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string IssueNumber { get; set; } = "";
        public string Publisher { get; set; } = "";
        public int? ReleaseYear { get; set; }
        public string? UPC { get; set; }
        public string? CoverPath { get; set; }

    }
}