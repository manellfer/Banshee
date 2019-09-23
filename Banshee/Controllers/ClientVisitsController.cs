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
    public class ClientVisitsController : Controller
    {
        private ModelContext _context;

        public ClientVisitsController(ModelContext context)
        {
            _context = context;
            if (_context.ClientVisits.Count() == 0)
            {
                _context.ClientVisits.Add(new ClientVisits
                {
                    ClientVisitsID = 1,
                    Date = DateTime.Now,
                    SalesRepresentative = 1,
                    Net = 100,
                    TotalVisit = 100, 
                    ClientID = 1
                });

                _context.ClientVisits.Add(new ClientVisits
                {
                    ClientVisitsID = 2,
                    Date = DateTime.Now,
                    SalesRepresentative = 1,
                    Net = 100,
                    TotalVisit = 100,
                    ClientID = 2
                });

                _context.ClientVisits.Add(new ClientVisits
                {
                    ClientVisitsID = 3,
                    Date = DateTime.Now,
                    SalesRepresentative = 1,
                    Net = 100,
                    TotalVisit = 100,
                    ClientID = 3
                });

                _context.SaveChanges();
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientVisits>>> GetClientVisits()
        {
            try
            {
                return await _context.ClientVisits.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("{ClienteID}")]
        public async Task<ActionResult<ClientVisits>> getClientVisits(int clientVistidID)
        {
            try
            {
                var customers = await _context.ClientVisits.FindAsync(clientVistidID);
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
        public async Task<ActionResult<ClientVisits>> postClientVisits(ClientVisits clientVisits)
        {

            try
            {
                _context.ClientVisits.Add(clientVisits);
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{ClientVisitID}")]
        public async Task<ActionResult<ClientVisits>> putClientVisits(int clientVisitID, ClientVisits clientVisits)
        {
            try
            {
                if (clientVisitID != clientVisits.ClientVisitsID)
                {
                    return BadRequest();
                }

                _context.Entry(clientVisits).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{ClientVisitID}")]
        public async Task<IActionResult> deleteClientVisits(int clientVisitID)
        {
            try
            {
                var clientVisits = await _context.ClientVisits.FindAsync(clientVisitID);
                if (clientVisits == null)
                {
                    return NotFound();
                }

                _context.ClientVisits.Remove(clientVisits);
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
