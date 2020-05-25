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
    [ApiExplorerSettings(GroupName = "CountriesAppOpenAPISpecCities")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CitiesController : Controller
    {

        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }





        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CityDTO>))]
        public IActionResult GetCities()
        {
            var objList = _cityRepository.GetCities();
            var objDto = new List<CityDTO>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<CityDTO>(obj));
            }
            return Ok(objDto);
        }





        [HttpGet("{cityId:int}", Name = "GetCity")]
        [ProducesResponseType(200, Type = typeof(CityDTO))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetCity(int cityId)
        {
            var obj = _cityRepository.GetCity(cityId);
            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<CityDTO>(obj);
            return Ok(objDto);
        }





        [HttpGet("[action]{countryId:int}")]
        [ProducesResponseType(200, Type = typeof(CityDTO))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetCitiyInCountry(int countryId)
        {
            var objList = _cityRepository.GetCitiesInCountry(countryId);
            if (objList == null)
            {
                return NotFound();
            }

            var objDTO = new List<CityDTO>();
            foreach (var obj in objList)
            {
                objDTO.Add(_mapper.Map<CityDTO>(obj));
            }
            return Ok(objDTO);
        }





        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CityDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCity([FromBody] CityCreateDTO cityDTO)
        {
            if (cityDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_cityRepository.CityExists(cityDTO.Name))
            {
                ModelState.AddModelError("", "City Exists!");
                return StatusCode(404, ModelState);
            }
            var cityObj = _mapper.Map<City>(cityDTO);
            if (!_cityRepository.CreateCity(cityObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {cityObj.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCity", new { cityId = cityObj.Id }, cityObj);
        }





        [HttpPatch("{cityId:int}", Name = "UpdateCity")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCity(int cityId, [FromBody] CityUpdateDTO cityDTO)
        {
            if (cityDTO == null || cityId != cityDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var cityObj = _mapper.Map<City>(cityDTO);
            if (!_cityRepository.UpdateCity(cityObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {cityObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }





        [HttpDelete("{cityId:int}", Name = "DeleteCity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCity(int cityId)
        {
            if (!_cityRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var cityObj = _cityRepository.GetCity(cityId);
            if (!_cityRepository.DeleteCity(cityObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {cityObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }




    }
}