using System;
using HotelListing.EndPoint.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using HotelListing.EndPoint.Models.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HotelListing.EndPoint.Data.Entities;
using HotelListiing.EndPoint.Data;
using HotelListing.EndPoint.Models;

namespace HotelListing.EndPoint.Controllers.Api
{

    [Route("api/Country")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly IUnitOfWork _uw;
        private readonly ILogger<IUnitOfWork> _uwlogger;
        private readonly AppDbContext _context;

        public CountryController(IUnitOfWork uw, ILogger<IUnitOfWork> uwlogger, AppDbContext context)
        {
            _uw = uw;
            _uwlogger = uwlogger;
            _context = context;
        }



        [HttpGet]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500)]
        public async Task<IActionResult> GetCountries([FromQuery] RequestParamter paramter)
        {
            var result = new List<CountryDto>();

            foreach (var item in await _uw.Countries.GetAll(paramter))
            {
                result.Add(new CountryDto { Countrycode = item.Countrycode, Hotels = item.Hotels, Id = item.Id, Name = item.Name, ShortName = item.ShortName });
            }

            return Ok(result);
        }


        [Authorize()]
        [HttpGet("{Id:int}", Name = "GetCountry")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500)]
        public async Task<IActionResult> GetCountry(int Id)
        {
            
            var country = await _uw.Countries.Get(q => q.Id == Id);
            

            if (country != null)
                return Ok(new CountryDto
                {
                    Countrycode = country.Countrycode,
                    Id = country.Id,
                    Hotels = await _uw.Hotels.GetAll(q => q.CountryId == country.Id),
                    Name = country.Name,
                    ShortName = country.ShortName
                });
            else
                return BadRequest();
        }



        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(statusCode: 400)]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var country = new Country
            {
                Name = model.Name,
                ShortName = model.ShortName,
                Countrycode = model.Countrycode
            };

            await _context.colunries.AddAsync(country);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return CreatedAtRoute("GetCountry", new { Id = country.Id }, country);
            else
            {
                _uwlogger.LogError($"Error accouerd in {nameof(CreateCountry)} during updating Database");
                return StatusCode(500, "Internal Pronlem , Please Try Later");
            }
        }


        [Authorize(Roles = "admin")]
        [HttpPut("{Id:int}")]
        [Route("EditCountry")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditCountry(int Id, [FromBody] UpdateCountryDto model)
        {

            if (!ModelState.IsValid || Id <= 0)
            {
                _uwlogger.LogError($"Error accoured in {nameof(EditCountry)} cause of ModelstateError : {ModelState} or NullExpcetionParamters");
                return BadRequest(ModelState);
            }
            else
            {
                var country = await _uw.Countries.Get(q => q.Id == Id);

                if (country == null)
                    return BadRequest("there is no country with this Identifier");


                country.Countrycode = model.Countrycode;
                country.Name = model.Name;
                country.ShortName = model.ShortName;


                _context.colunries.Update(country);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return Ok("Operation Sucssfuly done..");



                return StatusCode(500);

            }
        }


        [Authorize(Roles = "admin")]
        [Route("DeleteHotel")]
        [HttpDelete("{Id:int}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCountry(int Id)
        {
            if (Id <= 0)
            {
                _uwlogger.LogError($"Error in {nameof(DeleteCountry)} EndPoint Error description : NullOrEmptyParamter");
                return BadRequest("Paramter Should have value");
            }

            var country = await _uw.Countries.Get(q => q.Id == Id);

            if (country == null)
                return BadRequest("there is no country with this Identifier");


            _context.colunries.Remove(country);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return Ok("Operation Sucssfuly done..");



            return StatusCode(500);
        }

    }
}