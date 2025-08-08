using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var value = await _getCategoryQueryHandler.Handler()
                return Ok(value);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommands commands)
        {
            await _createCategoryCommandHandler.Handle(commands);
            return Ok("Category add has been succesful");
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommands(id));
            return Ok("Delete has been succesful");
        }
        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommands commands)
        {
            await _updateCategoryCommandHandler.Handle(commands);
            return Ok("Update has been succesful");
        }
        [HttpGet("GetCategory")]

        public async Task<IActionResult> GetCategoryById(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handler(new GetCategoryByIdQuery(id));
            return Ok(value);

        }
    }