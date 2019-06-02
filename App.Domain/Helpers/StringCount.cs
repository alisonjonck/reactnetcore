namespace App.Domain.Helpers
{
    public class StringCount
    {
        public StringCount(string value, int count)
        {
            Count = count;
            Value = value;
        }

        public int Count { get; set; }
        public string Value { get; set; }
    }
}
