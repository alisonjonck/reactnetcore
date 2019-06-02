using App.Domain.Constants;

namespace App.Domain.Helpers
{
    public static class StringExtensions
    {
        public static string RemovePrepositions(this string text, string stringReplace = " - ")
        {
            var newText = text;

            foreach (var preposition in StringResources.Prepositions)
            {
                newText = newText.Replace($" {preposition} ", stringReplace);
            }

            return newText;
        }
    }
}
