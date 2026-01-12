````markdown
```text
# QuestPDF integration (QuestPdfGenerator)

This document explains the new QuestPDF-based generator.

- NuGet package required:
  - QuestPDF (example: `dotnet add package QuestPDF`)

- Where to register:
  - Call `services.AddQuestPdf(Configuration)` from your Infrastructure DI registration (or call `services.AddSingleton<IQuestPdfGenerator, QuestPdfGenerator>()` manually).

- Usage:
  - API endpoint: POST /api/questpdf/generate with JSON matching `QuestDto`.
  - Returns `application/pdf` bytes.

- Notes:
  - QuestPDF renders synchronously to streams. It has a permissive license and supports advanced layout.
  - If you need custom fonts, register them per QuestPDF docs.
```
````
