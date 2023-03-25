using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
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

        [HttpPost]
        [Route("api/[controller]/Insert/{id}")]
        public ActionResult Insert(int id)
        {
            var data = new EnergyOccurrenc
            {
                Id = id,
                EnergyValue = id,
                Created_at = DateTime.Now,
            };
            _context.EnergyOccurences.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/GetPrice")]
        public IActionResult GetPrice()
        {
            List<EnergyOccurrenc> energyOccurences = _context.EnergyOccurences.ToList();
            int totalOfEnergy = 0;
            energyOccurences.ForEach(energyOccurence => totalOfEnergy += energyOccurence.EnergyValue);
            int energyAsWatt = totalOfEnergy * 220;
            int wattsAsKwh = energyAsWatt / 1000;
            double EnergyTax = 0.7358;
            double price = wattsAsKwh * EnergyTax;
            return Ok(price);
        }


    }
}