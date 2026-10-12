using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Rinzo.Core.Interfaces;

namespace Rinzo.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseApiController<TEntity, TRepository> : ControllerBase
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly IValidator<TEntity> _validator;

        protected BaseApiController(TRepository repository, IValidator<TEntity> validator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        #region Retrieve record GET request
        /// <returns>The list of records.</returns>
        /// <remarks>This method fetches all the records from the database using Entity Framework Core.</remarks>
        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }
        #endregion

        #region Retrieve record GET By ID request
        /// <returns>The record by ID.</returns>
        /// <remarks>This method fetches the record by ID from the database using Entity Framework Core.</remarks>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
        #endregion

        #region POST Request
        /// <returns>The newly created record.</returns>
        /// <remarks>This method posts the record to the database using Entity Framework Core.</remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TEntity entity)
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

            var result = await _repository.AddAsync(entity);
            return Ok(result);
        }
        #endregion
    }
}
