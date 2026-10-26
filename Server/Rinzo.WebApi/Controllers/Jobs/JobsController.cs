using Microsoft.AspNetCore.Mvc;
using Rinzo.Application.Export;
using Rinzo.Application.Jobs;

namespace Rinzo.WebApi.Controllers.Jobs;

[ApiController]
[Route("api/jobs")]
public sealed class JobsController(IJobService jobs, IExporterFactory<JobResponse> exporters)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(
        int page = 1,
        int pageSize = 20,
        CancellationToken ct = default
    ) => Ok(await jobs.GetPagedAsync(page, pageSize, ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct) =>
        Ok(await jobs.GetByIdAsync(id, ct));

    [HttpPost]
    [ProducesResponseType(typeof(JobResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(JobRequest request, CancellationToken ct)
    {
        var created = await jobs.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(Guid id, JobRequest request, CancellationToken ct)
    {
        await jobs.UpdateAsync(id, request, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await jobs.DeleteAsync(id, ct);
        return NoContent();
    }

    [HttpGet("export")]
    public async Task<IActionResult> Export(string format = "csv", CancellationToken ct = default)
    {
        var exporter = exporters.Get(format);
        var data = await jobs.ListAllAsync(ct);
        return File(exporter.Export(data), exporter.ContentType, $"jobs.{exporter.Format}");
    }
}
