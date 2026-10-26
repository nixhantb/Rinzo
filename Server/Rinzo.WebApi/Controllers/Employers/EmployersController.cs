using Microsoft.AspNetCore.Mvc;
using Rinzo.Application.Employers;
using Rinzo.Application.Export;

namespace Rinzo.WebApi.Controllers.Employers;

[ApiController]
[Route("api/employers")]
public sealed class EmployersController(
    IEmployerService employers,
    IExporterFactory<EmployerResponse> exporters
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(
        int page = 1,
        int pageSize = 20,
        CancellationToken ct = default
    ) => Ok(await employers.GetPagedAsync(page, pageSize, ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct) =>
        Ok(await employers.GetByIdAsync(id, ct));

    [HttpPost]
    [ProducesResponseType(typeof(EmployerResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(EmployerRequest request, CancellationToken ct)
    {
        var created = await employers.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(Guid id, EmployerRequest request, CancellationToken ct)
    {
        await employers.UpdateAsync(id, request, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await employers.DeleteAsync(id, ct);
        return NoContent();
    }

    [HttpGet("export")]
    public async Task<IActionResult> Export(string format = "csv", CancellationToken ct = default)
    {
        var exporter = exporters.Get(format);
        var data = await employers.ListAllAsync(ct);
        return File(exporter.Export(data), exporter.ContentType, $"employers.{exporter.Format}");
    }
}
