using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatkaLasku.Models;

namespace MatkaLasku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TripsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Trips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDTO>>> GetTrips()
        {
            return await _context.Trips
                .Select(t => TripToDTO(t))
                .ToListAsync();
        }

        // GET: api/Trips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripDTO>> GetTrip(long id)
        {
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound();
            }

            return TripToDTO(trip);
        }

        // PUT: api/Trips/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip(long id, TripDTO tripDTO)
        {
            if (id != tripDTO.Id)
            {
                return BadRequest();
            }

            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            trip.CompanyId = tripDTO.CompanyId;
            trip.Departure = tripDTO.Departure;
            trip.Recurrence = tripDTO.Recurrence;
            trip.Recipient = tripDTO.Recipient;
            trip.Purpose = tripDTO.Purpose;
            trip.DistanceInKM = tripDTO.DistanceInKM;
            trip.LocationDeparture = tripDTO.LocationDeparture;
            trip.LocationDestination = tripDTO.LocationDestination;
            trip.Description = tripDTO.Description;
            trip.PassengerCount = tripDTO.PassengerCount;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TripExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Trips
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TripDTO>> PostTrip(TripDTO tripDTO)
        {
            var trip = new Trip()
            {
                CompanyId = tripDTO.CompanyId,
                Departure = tripDTO.Departure,
                Recurrence = tripDTO.Recurrence,
                Recipient = tripDTO.Recipient,
                Purpose = tripDTO.Purpose,
                DistanceInKM = tripDTO.DistanceInKM,
                LocationDeparture = tripDTO.LocationDeparture,
                LocationDestination = tripDTO.LocationDestination,
                Description = tripDTO.Description,
                PassengerCount = tripDTO.PassengerCount
            };

            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTrip), 
                new { id = trip.Id }, 
                TripToDTO(trip)
            );
        }

        // DELETE: api/Trips/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TripDTO>> DeleteTrip(long id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return TripToDTO(trip);
        }

        private bool TripExists(long id)
        {
            return _context.Trips.Any(e => e.Id == id);
        }

        private static TripDTO TripToDTO(Trip trip) =>
            new TripDTO()
            {
                Id = trip.Id,
                CompanyId = trip.CompanyId,
                Departure = trip.Departure,
                Recurrence = trip.Recurrence,
                Recipient = trip.Recipient,
                Description = trip.Description,
                PassengerCount = trip.PassengerCount
            };
    }
}
