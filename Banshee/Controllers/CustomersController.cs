using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banshee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Banshee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ModelContext _context;

        public CustomersController(ModelContext context)
        {
            _context = context;
            /*if (_context.Customers.Count() == 0)
            {
                _context.Customers.Add(new Customers
                {
                    ClienteID = 1,
                    Nit = "1234",
                    FullName = "Bicycle S.A",
                    Address = "cra 2",
                    Phone = "3456",
                    CityID = 1,
                    StateID = 1,
                    CountryID = 1,
                    CreditLimit = 1000,
                    AvailableCredit = 100,
                    VisitPercentage = 50

                });

                _context.Customers.Add(new Customers
                {
                    ClienteID = 2,
                    Nit = "1234",
                    FullName = "Bicycle S.A",
                    Address = "cra 2",
                    Phone = "3456",
                    CityID = 1,
                    StateID = 1,
                    CountryID = 1,
                    CreditLimit = 1000,
                    AvailableCredit = 100,
                    VisitPercentage = 50

                });

                _context.Customers.Add(new Customers
                {
                    ClienteID = 3,
                    Nit = "12345",
                    FullName = "Bicycle S.A",
                    Address = "cra 2",
                    Phone = "3456",
                    CityID = 1,
                    StateID = 1,
                    CountryID = 1,
                    CreditLimit = 1000,
                    AvailableCredit = 100,
                    VisitPercentage = 50

                });

                _context.SaveChanges();
            }*/
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{ClientID}")]
        public async Task<ActionResult<Customers>> getCustomers(int clientID)
        {
            try
            {
                var customers = await _context.Customers.FindAsync(clientID);
                if (customers == null)
                {
                    return NotFound();
                }

                return customers;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customers>> postCustomers(Customers customers)
        {
            try
            {
                _context.Customers.Add(customers);
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{ClientID}")]
        public async Task<ActionResult<Customers>> putCustomers(long clientID, Customers customers)
        {
            try
            {
                if (clientID != customers.ClientID)
                {
                    return BadRequest();
                }

                _context.Entry(customers).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{ClientID}")]
        public async Task<IActionResult> deleteCustomers(int clientID)
        {
            try
            {
                var customers = await _context.Customers.FindAsync(clientID);
                if (customers == null)
                {
                    return NotFound();
                }

                _context.Customers.Remove(customers);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
