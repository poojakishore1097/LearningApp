using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearningApp.Models;

namespace LearningApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

     public class UserController : ControllerBase
    
     {
        private readonly UserDBContext _context;
        
        public UserController(UserDBContext context)
        {
             _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetTodoItems()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> PostTodoItems(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTodoItems", new { id = user.Id },user);
           // return CreatedAtAction("GetTodoItems", new { emailId = user.EmailId },user);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetTodoItem(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user== null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
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
        // POST: api/Users
       
       [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteTodoItem(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool TodoItemExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
         private bool TodoItemExists(string emailId)
        {
            return _context.Users.Any(e => e.EmailId == emailId);
        }
     
     }
}
