#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test1.Data;
using Test1.Data.Entities;
using Test1.Helper;

namespace Test1.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DataContext _context;


        public TicketsController(DataContext context)
        {
            _context = context;

        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _context.Tickets
                .Include(e => e.Entrance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

    
        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _context.Tickets
                .Include(e => e.Entrance)
                .FirstOrDefaultAsync(m=>m.Id==id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WasUsed,Document,Name,Date")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        
        

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
