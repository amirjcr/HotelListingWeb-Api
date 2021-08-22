using System;
using System.Collections.Generic;
using HotelListing.EndPoint.Models.Dtos;
using HotelListing.EndPoint.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using HotelListiing.EndPoint.Data;
using HotelListing.EndPoint.Data.Entities;
using HotelListing.EndPoint.Models;

namespace HotelListing.EndPoint.Controllers.Api
{

    [ApiController]
    [Route("api/TestController")]
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _uw;
        private readonly AppDbContext _context;
        private readonly ILogger<HotelController> _uwlogger;

        public HotelController(IUnitOfWork uw, ILogger<HotelController> uwlogger, AppDbContext context)
        {
            _uw = uw;
            _uwlogger = uwlogger;
            _context = context;
        }



        [HttpGet]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500)]
        public async Task<IActionResult> GetHotels([FromQuery] RequestParamter paramter)
        {
            try
            {
                var result = new List<HotelDto>();

                foreach (var item in await _uw.Hotels.GetAll(paramter))
                {
                    result.Add(new HotelDto
                    {
                        Address = item.Address,
                        CountryId = item.CountryId,
                        Id = item.Id,
                        Name = item.Name,
                        Rating = item.Rating
                    });
                }

                return Ok(result);
            }

            catch (Exception ex)
            {
                _uwlogger.LogError(ex, $"there are some Errors in CountryController in {nameof(GetHotels)} EndPoint");
                return StatusCode(500, "Internal Server Error Please Try Again Later");
            }
        }




        [HttpGet("{Id}", Name = "GetHotel")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500)]
        public async Task<IActionResult> GetHotel(string Id)
        {
            try
            {
                var hotel = await _uw.Hotels.Get(q => q.Id == Id);

                return Ok(new HotelDto
                {
                    Address = hotel.Address,
                    CountryId = hotel.CountryId,
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Rating = hotel.Rating
                });
            }

            catch (Exception ex)
            {
                _uwlogger.LogError(ex, $"there are some Errors in CountryController in {nameof(GetHotel)} EndPoint");
                return StatusCode(500, "Internal Server Error Please Try Again Later");
            }
        }


        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(statusCode: 400)]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hotel = new Hotel
            {
                Address = model.Address,
                Name = model.Name,
                Rating = model.Rating,
                CountryId = model.CountryId,
                Id = Guid.NewGuid().ToString()
            };

            await _context.Hotels.AddAsync(hotel);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return CreatedAtRoute("GetHotel", new { Id = hotel.Id }, hotel);
            else
            {
                _uwlogger.LogError($"Error accouerd in {nameof(CreateHotel)} during updating Database");
                return StatusCode(500, "Internal Pronlem , Please Try Later");
            }
        }



        [Authorize(Roles = "admin")]
        [HttpPut("{Id}")]
        [Route("EditCountry")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditHotel(string Id, [FromBody] UpdateHotelDto model)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(Id))
            {
                _uwlogger.LogError($"Error accoured in {nameof(EditHotel)} cause of ModelstateError : {ModelState} or NullExpcetionParamters");
                return BadRequest(ModelState);
            }
            else
            {
                var hotel = await _uw.Hotels.Get(q => q.Id == Id);

                if (hotel == null)
                    return BadRequest("there is no country with this Identifier");


                hotel.Address = model.Address;
                hotel.Name = model.Name;
                hotel.Rating = model.Rating;
                hotel.CountryId = model.CountryId;


                _context.Hotels.Update(hotel);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return Ok("Operation Sucssfuly done..");



                return StatusCode(500);

            }
        }


        [Authorize(Roles = "admin")]
        [Route("DeleteHotel")]
        [HttpDelete("{Id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteHotel(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                _uwlogger.LogError($"Error in {nameof(DeleteHotel)} EndPoint Error description : NullOrEmptyParamter");
                return BadRequest("Paramter Should have value");
            }


            var hotel = await _uw.Hotels.Get(q => q.Id == Id);

            if (hotel == null)
                return BadRequest("there is no country with this Identifier");


            _context.Hotels.Remove(hotel);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return Ok("Operation Sucssfuly done..");

            return StatusCode(500);

        }


    }
}