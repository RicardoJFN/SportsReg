using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsReg.Data;
using SportsReg.Models;

namespace SportsReg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly WorkoutContext _context;

        public WorkoutController(WorkoutContext context)
        {
            _context = context;
        }

        // GET: api/Workouts
        [HttpGet]
        [Route("GetWorkouts")]
        public IEnumerable<Workout> GetWorkouts()
        {
            return _context.Set<Workout>();
        }


        // GET: api/Workout/1
        [HttpGet]
        [Route("GetWorkout/{id}")]
        public async Task<IActionResult> GetWorkoutAsync(int id)
        {
            Workout workout = _context.Set<Workout>().Find(id);

            if (workout == null)
                return NotFound($"No workout with the id: {id}");

            return Ok(workout);
        }
    }
}