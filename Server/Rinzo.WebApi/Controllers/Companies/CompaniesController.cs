using Microsoft.AspNetCore.Mvc;
using Rinzo.Application.Companies;
using Rinzo.Application.Export;

namespace Rinzo.WebApi.Controllers.Companies;

[ApiController]
[Route("api/companies")]
public sealed class CompaniesController(
    ICompanyService companies,
    IExporterFactory<CompanyResponse> exporters
) : ControllerBase
{
    // GET /api/companies?page=1&pageSize=20
    [HttpGet]
    public async Task<IActionResult> GetAll(
        int page = 1,
        int pageSize = 20,
        CancellationToken ct = default
    ) => Ok(await companies.GetPagedAsync(page, pageSize, ct));

    // GET /api/companies/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct) =>
        Ok(await companies.GetByIdAsync(id, ct));

    // POST /api/companies
    [HttpPost]
    [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create(CompanyRequest request, CancellationToken ct)
    {
        var created = await companies.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT /api/companies/{id}
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(Guid id, CompanyRequest request, CancellationToken ct)
    {
        await companies.UpdateAsync(id, request, ct);
        return NoContent();
    }

    // DELETE /api/companies/{id}
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await companies.DeleteAsync(id, ct);
        return NoContent();
    }

    // GET /api/companies/export?format=csv
    [HttpGet("export")]
    public async Task<IActionResult> Export(string format = "csv", CancellationToken ct = default)
    {
        var exporter = exporters.Get(format);
        var data = await companies.ListAllAsync(ct);
        return File(exporter.Export(data), exporter.ContentType, $"companies.{exporter.Format}");
    }
}
