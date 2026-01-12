using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.Extensions.Options;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Infrastructure.Pdf;

/// <summary>
/// Implementation using QuestPDF (https://github.com/QuestPDF/QuestPDF)
/// </summary>
public class QuestPdfGenerator : IQuestPdfGenerator
{
    private readonly QuestPdfOptions _options;

    public QuestPdfGenerator(IOptions<QuestPdfOptions> options)
    {
        _options = options?.Value ?? new QuestPdfOptions();
    }

    public Task<byte[]> GenerateQuestPdfAsync(QuestDto dto, CancellationToken cancellationToken = default)
    {
        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Header()
                    .PaddingBottom(10)
                    .Row(row =>
                    {
                        row.RelativeColumn().Stack(stack =>
                        {
                            stack.Item().Text(dto.Title ?? string.Empty).FontSize(20).Bold();
                            stack.Item().Text($"By {dto.Author ?? string.Empty}").FontSize(12).SemiBold();
                        });

                        row.ConstantColumn(140).AlignRight().Text($"Created: {dto.CreatedAt:yyyy-MM-dd}");
                    });

                page.Content()
                    .PaddingVertical(10)
                    .Column(column =>
                    {
                        column.Item().Text(dto.Description ?? string.Empty).FontSize(12);
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x => x.Span("Page ").CurrentPageNumber().Span(" / ").TotalPages());
            });
        });

        using var ms = new MemoryStream();
        doc.GeneratePdf(ms);
        var bytes = ms.ToArray();
        return Task.FromResult(bytes);
    }
}
