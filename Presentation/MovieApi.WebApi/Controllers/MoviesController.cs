using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handler();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommands commands)
        {
            await _createMovieCommandHandler.Handle(commands);
            return Ok("Movie has been added successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handler(new RemoveMovieCommands(id));
            return Ok("Movie has been deleted successfully");
        }

        public GetMovieByIdQueryHandler Get_getMovieByIdQueryHandler()
        {
            return _getMovieByIdQueryHandler;
        }

        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommands commands)
        {
            await _updateMovieCommandHandler.Handle(commands);
            return Ok("Movie has been updated successfully");

        }
    }