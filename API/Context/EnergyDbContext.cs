using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class EnergyDbContext : DbContext
    {
        public DbSet<EnergyOccurrenc> EnergyOccurences { get; set; }
        public EnergyDbContext(DbContextOptions<EnergyDbContext> options) : base(options)
        {

        }
    }
}