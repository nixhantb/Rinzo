using FluentValidation;
using JobLeet.WebApi.JobLeet.Api.Exceptions;
using JobLeet.WebApi.JobLeet.Api.Logging;
using JobLeet.WebApi.JobLeet.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobLeet.WebApi.JobLeet.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseApiController<TEntity, TModel, TService> : ControllerBase
        where TEntity : class
        where TModel : class
        where TService : IService<TEntity, TModel>
    {
        protected readonly TService _service;
        protected readonly IValidator<TEntity> _validator;

        protected BaseApiController(TService service, IValidator<TEntity> validator)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        #region Retrieve record GET request
        /// <returns>The list of records.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches all the records from the database using Entity Framework Core.</remarks>
        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var entities = await _service.GetAllAsync();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                var errorResponse = new GlobalErrorResponse
                {
                    Error = "Internal Server Error",
                    Message = ex.Message,
                };
                return StatusCode(500, errorResponse);
            }
        }
        #endregion

        #region Retrieve record GET By ID request
        /// <returns>The record by ID.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method fetches the record by ID from the database using Entity Framework Core.</remarks>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);

                if (entity == null)
                    return NotFound();

                return Ok(entity);
            }
            catch (Exception ex)
            {
                var errorResponse = new GlobalErrorResponse
                {
                    Error = "System Exception",
                    Message = ex.Message,
                };
                return StatusCode(400, errorResponse);
            }
        }
        #endregion

        #region POST Request
        /// <returns>The newly created record.</returns>
        /// <exception cref="Exception">Thrown when there is an error while fetching data from the database.</exception>
        /// <remarks>This method posts the record to the database using Entity Framework Core.</remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest();
                }
                var validationResult = _validator.Validate(entity);
                if (!validationResult.IsValid)
                {
                    return BadRequest(
                        new
                        {
                            Message = "Validation failed.",
                            Errors = validationResult.Errors.Select(e => new
                            {
                                e.PropertyName,
                                e.ErrorMessage,
                            }),
                        }
                    );
                }
                var result = await _service.AddAsync(entity);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new GlobalErrorResponse
                {
                    Error = "System Exception",
                    Message = ex.Message,
                };
                return StatusCode(400, errorResponse);
            }
        }
        #endregion
    }
}
