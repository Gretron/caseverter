using System.Globalization;
using System.Text.RegularExpressions;

namespace caseverter
{
    /// <summary>
    /// Helper to Aid String Operations
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Turn <see cref="string"/> Into Titlecase
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToTitle(this string text)
        {
            // Input to Lowercase
            text = text.ToLower();

            // Get Culture Info
            TextInfo info = new CultureInfo("en-US", false).TextInfo;

            return info.ToTitleCase(text);
        }

        /// <summary>
        /// Turn <see cref="string"/> Into Titlecase
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToAPATitle(this string text)
        {
            // Input to Lowercase
            text = text.ToLower();

            // Get Culture Info
            TextInfo info = new CultureInfo("en-US", false).TextInfo;

            // Match All Titlecase Scenarios
            var wordRegex = new Regex(@"(\s|-|"")[a-z]|^[a-z]", RegexOptions.Multiline);
            var conjunctionRegex = new Regex(@"(?<=(\s|-|""))(and|as|but|for|if|nor|or|so|yet)(?=(\s|-|""))", RegexOptions.IgnoreCase);
            var articleRegex = new Regex(@"(?<=(\s|-|""))(a|an|the)(?=(\s|-|""))", RegexOptions.IgnoreCase);
            var prepositionRegex = new Regex(@"(?<=(\s|-|""))(at|by|in|of|off|on|per|to|via)(?=(\s|-|""))", RegexOptions.IgnoreCase);
            var adverbRegex = new Regex(@"(?<=((turn|switch)(\s+)(the)?(.+)?(\s+)?))(on|off)", RegexOptions.IgnoreCase);
            var adjectiveRegex = new Regex(@"(?<=((is|turn|turned|goes|go|jump)(\s+)))(on|off|in)", RegexOptions.IgnoreCase);
            var startRegex = new Regex(@"(?<=[.!?:](\s)+)\b[a-z]", RegexOptions.Multiline);

            // Apply Regex
            text = wordRegex.Replace(text, s => info.ToTitleCase(s.Value));
            text = conjunctionRegex.Replace(text, s => s.Value.ToLower());
            text = articleRegex.Replace(text, s => s.Value.ToLower());
            text = prepositionRegex.Replace(text, s => s.Value.ToLower());
            text = adverbRegex.Replace(text, s => info.ToTitleCase(s.Value));
            text = adjectiveRegex.Replace(text, s => info.ToTitleCase(s.Value));
            text = startRegex.Replace(text, s => info.ToTitleCase(s.Value));

            return text;
        }

        /// <summary>
        /// Turn <see cref="string"/> Into Sentencecase
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSentence(this string text)
        {
            // Input to Lowercase
            text = text.ToLower();

            // Match All Start of Sentences
            var regex = new Regex(@"(^([^a-z0-9]+)?[a-z])|([?!.][^a-z0-9]+[a-z])", RegexOptions.Multiline);

            text = regex.Replace(text.ToLower(), s => s.Value.ToUpper());

            return text;
        }

        /// <summary>
        /// Turn <see cref="string"/> Into Alternatingcase
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToAlternating(this string text)
        {
            // Input to Lowercase
            text = text.ToLower();

            var chars = text.ToCharArray();
            var count = 1;

            for(int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    // Every Two Characters Turn to Uppercase
                    if (count % 2 == 0)
                        chars[i] = char.ToUpper(chars[i]);

                    count++;
                }
            }

            return string.Join("", chars);
        }
    }
}
