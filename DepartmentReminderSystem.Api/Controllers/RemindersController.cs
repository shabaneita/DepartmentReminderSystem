using DepartmentReminderSystem.Application.Interfaces;
using DepartmentReminderSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentReminderSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemindersController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

        public RemindersController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReminders()
        {
            var reminders = await _context.Reminders.ToListAsync();
            return Ok(reminders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReminder(int id)
        {
            var reminder = await _context.Reminders.FindAsync(id);

            if (reminder == null)
                return NotFound();

            return Ok(reminder);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReminder([FromBody] Reminder reminder)
        {
            _context.Reminders.Add(reminder);
            await _context.SaveChangesAsync(default);
            return CreatedAtAction(nameof(GetReminder), new { id = reminder.Id }, reminder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReminder(int id, [FromBody] Reminder reminder)
        {
            if (id != reminder.Id)
                return BadRequest();

            _context.Entry(reminder).State = EntityState.Modified;
            await _context.SaveChangesAsync(default);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            var reminder = await _context.Reminders.FindAsync(id);
            if (reminder == null)
                return NotFound();

            _context.Reminders.Remove(reminder);
            await _context.SaveChangesAsync(default);
            return NoContent();
        }
    }
}
