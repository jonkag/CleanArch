using System;
using System.Threading.Tasks;
using Application.Common.Models;
using Infrastructure.Pdf;
using Microsoft.Extensions.Options;
using Xunit;

namespace Infrastructure.Tests;

public class QuestPdfGeneratorTests
{
    [Fact]
    public async Task GenerateQuestPdf_ReturnsBytes()
    {
        var options = Options.Create(new QuestPdfOptions());
        var generator = new QuestPdfGenerator(options);

        var dto = new QuestDto
        {
            Title = "Test Quest",
            Description = "This is a short description for unit test.",
            Author = "unit-test",
            CreatedAt = DateTime.UtcNow
        };

        var bytes = await generator.GenerateQuestPdfAsync(dto);

        Assert.NotNull(bytes);
        Assert.NotEmpty(bytes);
        Assert.True(bytes.Length > 100);
        // Check for %PDF- header
        Assert.Equal((byte)'%', bytes[0]);
        Assert.Equal((byte)'P', bytes[1]);
        Assert.Equal((byte)'D', bytes[2]);
        Assert.Equal((byte)'F', bytes[3]);
        Assert.Equal((byte)'-', bytes[4]);
    }
}
