using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CountriesAppAPI.DTOs;
using CountriesAppAPI.Models;
using CountriesAppAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountriesAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "CountriesAppOpenAPISpecCountries")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CountriesController : Controller
    {

        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }





        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CountryDTO>))]
        public IActionResult GetCountries()
        {
            var objList = _countryRepository.GetCountries();
            var objDto = new List<CountryDTO>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<CountryDTO>(obj));
            }
            return Ok(objDto);
        }





        [HttpGet("{countryId:int}", Name = "GetCountry")]
        [ProducesResponseType(200, Type = typeof(CountryDTO))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetCountry(int countryId)
        {
            var obj = _countryRepository.GetCountry(countryId);
            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<CountryDTO>(obj);
            return Ok(objDto);
        }





        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CountryDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCountry([FromBody] CountryDTO countryDTO)
        {
            if (countryDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_countryRepository.CountryExists(countryDTO.Name))
            {
                ModelState.AddModelError("", "Country Exists!");
                return StatusCode(404, ModelState);
            }
            var countryObj = _mapper.Map<Country>(countryDTO);
            if (!_countryRepository.CreateCountry(countryObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {countryObj.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCountry", new { countryId = countryObj.Id }, countryObj);
        }





        [HttpPatch("{countryId:int}", Name = "UpdateCountry")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDTO countryDTO)
        {
            if (countryDTO == null || countryId != countryDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var countryObj = _mapper.Map<Country>(countryDTO);
            if (!_countryRepository.UpdateCountry(countryObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {countryObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }





        [HttpDelete("{countryId:int}", Name = "DeleteCountry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
            {
                return NotFound();
            }

            var countryObj = _countryRepository.GetCountry(countryId);
            if (!_countryRepository.DeleteCountry(countryObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {countryObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }




    }
}