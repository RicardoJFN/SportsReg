using Microsoft.EntityFrameworkCore;
using SportsReg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsReg.Data
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options)
        {

        }

        public DbSet<Workout> Workouts { get; set; }
    }
}
