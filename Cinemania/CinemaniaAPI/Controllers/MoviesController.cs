using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaniaAPI.Mapper;
using CinemaniaAPI.Models;
using CinemaniaAPI.Models.DTO;
using CinemaniaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaniaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository , IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        
     
        [HttpGet]
        [ProducesResponseType(200 , Type = typeof(List<MovieDTO>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllMovies()
        {
            var movieList = _movieRepository.GetMovies();

            //Convert domain models to DTO
            var movieListDTO = new List<MovieDTO>();
            foreach (var movie in movieList)
            {
                movieListDTO.Add(_mapper.Map<MovieDTO>(movie));
            }

            return Ok(movieListDTO);
        }


        [HttpGet("{movieId:int}" , Name = "GetMovie")]
        [ProducesResponseType(200, Type = typeof(MovieDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetMovie(int movieId)
        {
            var movie = _movieRepository.GetMovie(movieId);
            if(movie == null)
            {
                return NotFound();
            }

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return Ok(movieDTO);
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(MovieDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateMovie([FromBody] MovieDTO movieDTO)
        {
            //Check for errors
            if(movieDTO == null)
            {
                return BadRequest(ModelState); // ModelState contains all Errors if they are encountered
            }

            if (_movieRepository.MovieExists(movieDTO.Title))
            {
                ModelState.AddModelError("", "The Movie already exists in our database!");
                return StatusCode(404 , ModelState);
            }


            //If there is no error convert movieDTO to movie domain model
            var movie = _mapper.Map<Models.Movie>(movieDTO);

            //if movie wasnt created 
            if (!_movieRepository.CreateMovie(movie))
            {
                ModelState.AddModelError("", "Something went wrong :( !");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetMovie" , new { movieId = movie.Id } , movie);
        }


        [HttpPatch("{movieId:int}", Name = "UpdateMovie")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateMovie(int movieId , [FromBody] MovieDTO movieDTO)
        {
            //Check for errors
            if (movieDTO == null || movieId != movieDTO.Id)
            {
                return BadRequest(ModelState); // ModelState contains all Errors if they are encountered
            }

            if (_movieRepository.MovieExists(movieDTO.Title))
            {
                ModelState.AddModelError("", "The Movie already exists in our database!");
                return StatusCode(404, ModelState);
            }

            //If there is no error convert movieDTO to movie domain model
            var movie = _mapper.Map<Models.Movie>(movieDTO);

            //if movie wasnt created 
            if (!_movieRepository.UpdateMovie(movie))
            {
                ModelState.AddModelError("", "Something went wrong :( !");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{movieId:int}", Name = "DeleteMovie")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteMovie(int movieId)
        {
            if (!_movieRepository.MovieExists(movieId))
            {
                return NotFound();
            }

            var movieObj = _movieRepository.GetMovie(movieId);

            if (!_movieRepository.DeleteMovie(movieObj))
            {
                ModelState.AddModelError("", "Something went wrong :( !");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
