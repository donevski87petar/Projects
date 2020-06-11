using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOSSCompanyAPI.Models;
using BOSSCompanyAPI.Repository.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BOSSCompanyAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SocksController : ControllerBase
    {
        private readonly ISockRepository _sockRepository;
        public SocksController(ISockRepository sockRepository)
        {
            _sockRepository = sockRepository;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Sock>))]
        public IActionResult GetAllProducts()
        {
            var sockList = _sockRepository.GetSocks();

            return Ok(sockList);
        }


        [HttpGet("{sockId:int}", Name = "GetSock")]
        [ProducesResponseType(200, Type = typeof(Sock))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetSock(int sockId)
        {
            var sock = _sockRepository.GetSock(sockId);

            if (sock == null)
            {
                return NotFound();
            }
            return Ok(sock);
        }



        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Sock))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCountry([FromBody] Sock sock)
        {
            if (sock == null)
            {
                return BadRequest(ModelState);
            }

            if (!_sockRepository.CreateSock(sock))
            {
                ModelState.AddModelError("", $"Something went wrong!");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetSock", new { sockId = sock.Id }, sock);
        }



        [HttpPatch("{sockId:int}", Name = "UpdateSock")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateSock(int sockId, [FromBody] Sock sock)
        {
            if (sock == null || sockId != sock.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_sockRepository.UpdateSock(sock))
            {
                ModelState.AddModelError("", $"Something went wrong!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }



        [HttpDelete("{sockId:int}", Name = "DeleteSock")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteSock(int sockId)
        {
            var sockObj = _sockRepository.GetSock(sockId);
            if (!_sockRepository.DeleteSock(sockObj))
            {
                ModelState.AddModelError("", $"Something went wrong!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }










    }
}