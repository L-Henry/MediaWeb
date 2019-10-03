using MediaWeb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    [Route("api/regisseur")]
    public class ApiController : Controller
    {
        private readonly MediaContext _context;

        public ApiController(MediaContext context)
        {
            _context = context;
        }


        [Produces("application/json")]
        [HttpGet("search")]
        public IActionResult Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = _context.MovieRegisseur.Where(p => p.Naam.Contains(term)).Select(p => p.Naam).ToList();
                return Ok(names);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
