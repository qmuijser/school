using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Context;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderLinesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/OrderLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLine>>> GetOrderLine()
        {
            return await _context.OrderLine.ToListAsync();
        }

        // GET: api/OrderLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderLine>> GetOrderLine(int id)
        {
            var orderLine = await _context.OrderLine.FindAsync(id);

            if (orderLine == null)
            {
                return NotFound();
            }

            return orderLine;
        }

        // PUT: api/OrderLines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderLine(int id, OrderLine orderLine)
        {
            if (id != orderLine.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(id))
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

        // POST: api/OrderLines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderLine>> PostOrderLine(OrderLine orderLine)
        {
            _context.OrderLine.Add(orderLine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderLineExists(orderLine.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderLine", new { id = orderLine.OrderId }, orderLine);
        }

        // DELETE: api/OrderLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderLine>> DeleteOrderLine(int id)
        {
            var orderLine = await _context.OrderLine.FindAsync(id);
            if (orderLine == null)
            {
                return NotFound();
            }

            _context.OrderLine.Remove(orderLine);
            await _context.SaveChangesAsync();

            return orderLine;
        }

        private bool OrderLineExists(int id)
        {
            return _context.OrderLine.Any(e => e.OrderId == id);
        }
    }
}
