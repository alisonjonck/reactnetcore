namespace App.Domain.Models
{
    public class FeedTopic
    {
        public string Title { get; set; }
        public bool IsMocked { get; set; }

        public FeedTopic(string title, bool isMocked)
        {
            Title = title;
            IsMocked = isMocked;
        }
    }
}
