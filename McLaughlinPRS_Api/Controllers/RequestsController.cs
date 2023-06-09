﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using McLaughlinPRS_Api.Models;
using System.Xml.Schema;

namespace McLaughlinPRS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly McLaughlinDbContext _context;

        public RequestsController(McLaughlinDbContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.Include(x => x.User)
                                        .Include(x => x.Requestlines)
                                        .ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.Include(x => x.User)
                                        .Include(x => x.Requestlines)
                                        .SingleOrDefaultAsync(x => x.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }


        // **METHOD 5, ADDED 3/15/23
        // GET: /api/requests/reviews/{userId}
        [HttpGet("reviews/{userId}")]
        public async Task<ActionResult<ICollection<Request>>> GetReviews(int userId)
        {
            return await _context.Requests.Where(x => x.Status == "REVIEW" && x.UserId != userId )                                    
                                          .ToListAsync();
        }
        // ##OPERATION CONFIRMED, 3/15/23


        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // **METHOD 2, ADDED 3/14/23
        // PUT: api/requests/review/5 
        [HttpPut("review/{id}")]
        public async Task<IActionResult> ReviewReq(int id, Request request)
        {
            if (request.Total > 50)
            {
                request.Status = "REVIEW";
            }
            else
            {
                request.Status = "APPROVED";
            }
            return await PutRequest(id, request);
        }
        // ##OPERATION CONFIRMED, 3/15/23


        // **METHOD 3 - ADDED 3/15/23
        // PUT: api/requests/approved/5
        [HttpPut("approved/{id}")]
        public async Task<IActionResult> ApprovedReq(int id, Request request)
        {
            request.Status = "APPROVED";
            return await PutRequest(id, request);
        }
        // ##OPERATION CONFIRMED, 3/15/23


        // **METHOD 4 - ADDED 3/15/23
        // PUT: api/requests/reject/5
        [HttpPut("reject/{id}")]
        public async Task<IActionResult> RejectReq(int id, Request request)
        {
            request.Status = "REJECT";
            return await PutRequest(id, request);
        }
        // ##OPERATION CONFIRMED, 3/15/23



        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
