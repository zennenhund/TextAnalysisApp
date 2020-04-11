using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextAnalysisApp.Models;

namespace TextAnalysisApp.Implementation
{
    public class TextAnalysisService : ITextAnalysisService
    {
        public async Task<TextAnalysisOutput> GetCharactersCountAsync(TextAnalysisIntput input)
        {
            var str = new StringBuilder(input.Text.Length); 
            using (var reader = new StringReader(input.Text))
            {
                int i = 0;
                char c;
                for (; i < input.Text.Length; i++)
                {
                    c = (char)reader.Read();
                    if (!char.IsWhiteSpace(c))
                    {
                        str.Append(c);
                    }
                }
            }

            var result = new TextAnalysisOutput()
            {
                Description = $"This text includes {str.Length} characters!"
            };

            return result;
        }

        public async Task<TextAnalysisOutput> GetWordsCountAsync(TextAnalysisIntput input)
        {
            if (string.IsNullOrWhiteSpace(input.Text))
            {
                return null;
            }

            int count = Regex.Matches(input.Text, @"[A-Za-z0-9]+").Count;
            var result = new TextAnalysisOutput()
            {
                Description = $"This text includes {count} words!"
            };

            return result;
        }
    }
}
