namespace DAWM_API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string MainActor { get; set; }
        public int ReleaseYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }  
        public float Rating { get; set; }  
    }
}
