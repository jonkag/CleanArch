namespace Application.Common.Interfaces;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;

/// <summary>
/// A minimal abstraction for generating quest PDFs.
/// </summary>
public interface IQuestPdfGenerator
{
    /// <summary>
    /// Generate a PDF for the provided quest DTO and return the bytes.
    /// </summary>
    Task<byte[]> GenerateQuestPdfAsync(QuestDto dto, CancellationToken cancellationToken = default);
}
