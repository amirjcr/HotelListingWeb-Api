using System;
using HotelListiing.EndPoint.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;



namespace HotelListing.EndPoint.Controllers.ApiV2
{

    [ApiVersion("2.0", Deprecated = true)]
    [ApiController]
    [Route("api/country")]
    public class CountryV2Controller : Controller
    {
        private readonly AppDbContext _context;

        public CountryV2Controller(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetCountries() => Ok(await _context.colunries.ToListAsync());
    }
}