using Application.Features.Category.Commands;
using Application.Features.Category.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/categories")]
    [ApiVersion("1.0")]
    public class CategoryController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetCategoryListQuery query)
        {
            var result = await Mediator.Send(query);
            return StatusCode(result.HttpStatusCode, result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetCategoryByIdQuery { Id = id });
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteCategoryCommand { Id = id });
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
        {
            command.Id = id;
            var result = await Mediator.Send(command);
            return StatusCode(result.HttpStatusCode, result);
        }
    }
}
