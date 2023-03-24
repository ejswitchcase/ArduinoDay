using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class EnergyController : Controller
    {
        private readonly EnergyDbContext _context;

        public EnergyController(EnergyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]/GetData")]
        public IActionResult GetData()
        {
            var data = _context.EnergyOccurences.ToList();
            return Ok(data);
        }

    }
}