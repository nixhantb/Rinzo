using Microsoft.AspNetCore.Mvc;
using Rinzo.Application.Applications;
using Rinzo.Application.Export;

namespace Rinzo.WebApi.Controllers.Applications;

[ApiController]
[Route("api/applications")]
public sealed class ApplicationsController(
    IApplicationService applications,
    IExporterFactory<JobApplicationResponse> exporters
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(
        int page = 1,
        int pageSize = 20,
        CancellationToken ct = default
    ) => Ok(await applications.GetPagedAsync(page, pageSize, ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct) =>
        Ok(await applications.GetByIdAsync(id, ct));

    // POST /api/applications - a seeker applies to a job.
    [HttpPost]
    [ProducesResponseType(typeof(JobApplicationResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create(JobApplicationRequest request, CancellationToken ct)
    {
        var created = await applications.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /api/applications/{id}/status - move the application through its review.
    [HttpPut("{id:guid}/status")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateStatus(
        Guid id,
        JobApplicationStatusRequest request,
        CancellationToken ct
    )
    {
        await applications.UpdateStatusAsync(id, request, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await applications.DeleteAsync(id, ct);
        return NoContent();
    }

    [HttpGet("export")]
    public async Task<IActionResult> Export(string format = "csv", CancellationToken ct = default)
    {
        var exporter = exporters.Get(format);
        var data = await applications.ListAllAsync(ct);
        return File(exporter.Export(data), exporter.ContentType, $"applications.{exporter.Format}");
    }
}
