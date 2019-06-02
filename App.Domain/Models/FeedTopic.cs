namespace App.Domain.Models
{
    public class FeedTopic
    {
        public string Title { get; set; }

        public FeedTopic(string title)
        {
            Title = title;
        }
    }
}
