using System;
using System.Threading.Tasks;

namespace TextAnalysis.Services
{
    interface ITextAnalysisService
    {
        Task<TextAnalysisDto> GetWordsCount(string text);
    }
}
