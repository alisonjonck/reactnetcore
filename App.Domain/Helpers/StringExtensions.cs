using System.Collections.Generic;
using System.Linq;
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

        public static IList<StringCount> MostUsed(this IList<string> texts, int limit = 10)
        {
            string allTexts = string.Empty;

            foreach (var text in texts)
            {
                allTexts += $" {text.ToLower()}";
            }

            var mostUsedList = allTexts.Replace(",", " ").Split(" ")
              .Where(x => !string.IsNullOrWhiteSpace(x))
              .GroupBy(x => x)
              .Select(x => new
              {
                  KeyField = x.Key,
                  Count = x.Count()
              })
              .OrderByDescending(x => x.Count)
              .Take(limit);

            return mostUsedList
                .Select(x => new StringCount(x.KeyField, x.Count))
                .ToList();
        }
    }
}
