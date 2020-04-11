using System.Threading.Tasks;
using TextAnalysisApp.Models;

namespace TextAnalysisApp
{
    public interface ITextAnalysisService
    {
        Task<TextAnalysisOutput> GetWordsCountAsync(TextAnalysisIntput input);

        Task<TextAnalysisOutput> GetCharactersCountAsync(TextAnalysisIntput input);
    }
}
