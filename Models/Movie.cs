namespace DAWM_API.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string MainActor { get; set; }

        public string Image { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }  
        public float Rating { get; set; }  
    }
}
