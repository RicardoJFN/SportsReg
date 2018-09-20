using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/Workout/GetWorkouts
        [HttpGet]
        [Route("GetWorkouts")]
        public IEnumerable<Workout> GetWorkouts()
        {
            return _context.Set<Workout>();
        }


        // GET: api/Workout/GetWorkout/1
        [HttpGet]
        [Route("GetWorkout/{id}")]
        public async Task<IActionResult> GetWorkoutAsync(int id)
        {
            Workout workout = _context.Set<Workout>().Find(id);

            if (workout == null)
                return NotFound($"No workout with the id: {id}");

            return Ok(workout);
        }

        // PUT: api/Workout/UpdateWorkout/1
        [HttpPut]
        [Route("UpdateWorkout/{id}")]
        public async Task<IActionResult> UpdateWorkoutAsync(int id)
        {
            Workout workout = _context.Set<Workout>().Find(id);

            if (workout == null)
                return NotFound("$No workout with the id: {id}");

            _context.Entry(workout).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Workout updated");
        }

        // POST: api/Workout/SaveWorkout
        [HttpPost]
        [Route("SaveWorkout")]
        public async Task<IActionResult> SaveWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return Ok("Workout created");
        }

        // DELETE: api/Workout/DeleteWorkout/1
        [HttpDelete]
        [Route("DeleteWorkout/{1}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            Workout workout = _context.Set<Workout>().Find(id);

            if (workout == null)
                return NotFound($"No workout with the id: {id}");

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return Ok("Workout deleted");
        }

        
    }
}