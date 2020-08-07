using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatkaLasku.Models;

namespace MatkaLasku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public InvoicesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Invoices/2
        [HttpGet("{CompanyId}")]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetInvoicesByCompanyId(long CompanyId)
        {
            return await _context.Trips
                .Where(t => t.CompanyId == CompanyId)
                .Include(t => t.Company)
                .Select(t => ToInvoiceDTO(t, t.Company))
                .ToListAsync();
        }

        public static InvoiceDTO ToInvoiceDTO(Trip trip, Company company)
        {
            var invoiceCalculator = new InvoiceCalculator(trip.PassengerCount, trip.DistanceInKM, trip.Departure, trip.Recurrence);

            return new InvoiceDTO() {
                InvoiceNumber = trip.Id,
                CompanyName = company.Name,
                Departure = trip.Departure,
                RecurrenceTime = trip.Recurrence,
                BenefitReciever = trip.Recipient,
                Purpose = trip.Purpose,
                DistanceInKM = trip.DistanceInKM,
                LocationDeparture = trip.LocationDeparture,
                LocationDestination = trip.LocationDestination,
                Description = trip.Description,
                PassengerCount = trip.PassengerCount,
                KMAllowanceUnit = invoiceCalculator.CompensationPerKM,
                KMAllowanceTotal = invoiceCalculator.CalculateKMAllowance(),
                PartDayBenefit = invoiceCalculator.PartDayBenefit,
                FullDayBenefit = invoiceCalculator.FullDayBenefit,
                TotalFullDaysBenefit = invoiceCalculator.CalculateTotalFullDaysBenefit(),
                TotalDayBenefit = invoiceCalculator.CalculateTotalDayBenefit(),
                Total = invoiceCalculator.CalculateTotal(),
                Created = trip.Created
            };
        }
    }
}