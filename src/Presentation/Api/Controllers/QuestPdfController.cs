using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestPdfController : ControllerBase
{
    private readonly IQuestPdfGenerator _generator;

    public QuestPdfController(IQuestPdfGenerator generator)
    {
        _generator = generator;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> Generate([FromBody] QuestDto dto)
    {
        var bytes = await _generator.GenerateQuestPdfAsync(dto);
        var fileName = string.IsNullOrWhiteSpace(dto?.Title) ? "quest.pdf" : $"{dto.Title}.pdf";
        return File(bytes, "application/pdf", fileName);
    }
}
