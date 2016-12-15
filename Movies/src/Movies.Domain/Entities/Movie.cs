namespace Movies.Domain
{
    public class Movie
    {
        public string Title { get; set; }

        public string TrailerVideoUrl { get; set; }

        public string Country { get; set; } = "N/A";

        public int Year { get; set; }

        public override string ToString() => $"{Title}, {Year}";
    }
}