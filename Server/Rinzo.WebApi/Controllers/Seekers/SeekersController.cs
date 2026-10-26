using Microsoft.AspNetCore.Mvc;
using Rinzo.Application.Export;
using Rinzo.Application.Seekers;

namespace Rinzo.WebApi.Controllers.Seekers;

[ApiController]
[Route("api/seekers")]
public sealed class SeekersController(
    ISeekerService seekers,
    IExporterFactory<SeekerResponse> exporters
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(
        int page = 1,
        int pageSize = 20,
        CancellationToken ct = default
    ) => Ok(await seekers.GetPagedAsync(page, pageSize, ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct) =>
        Ok(await seekers.GetByIdAsync(id, ct));

    [HttpPost]
    [ProducesResponseType(typeof(SeekerResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(SeekerRequest request, CancellationToken ct)
    {
        var created = await seekers.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(Guid id, SeekerRequest request, CancellationToken ct)
    {
        await seekers.UpdateAsync(id, request, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await seekers.DeleteAsync(id, ct);
        return NoContent();
    }

    [HttpGet("export")]
    public async Task<IActionResult> Export(string format = "csv", CancellationToken ct = default)
    {
        var exporter = exporters.Get(format);
        var data = await seekers.ListAllAsync(ct);
        return File(exporter.Export(data), exporter.ContentType, $"seekers.{exporter.Format}");
    }
}
