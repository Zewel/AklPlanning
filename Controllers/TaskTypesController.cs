using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweaterPlanning.Models;
using SweaterPlanning.SecureDataClass;

namespace SweaterPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TaskTypesController : ControllerBase
    {
        private readonly CodeDbSet _context;

        private TaskTypeDAL _aDAL = new TaskTypeDAL();
        public TaskTypesController(CodeDbSet context)
        {
            _context = context;
        }

        // GET: api/TaskTypes/GetTaskTypes
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<TaskType>>> GetTaskTypes()
        {
            return await _context.TaskType.ToListAsync();
        }

        // GET: api/TaskTypes/GetTaskType/5
        [HttpGet("{id}")]

        [Route("TaskTypes/GetTaskType/{id}")]
        public async Task<ActionResult<TaskType>> GetTaskType(int id)
        {
            var taskType = await _context.TaskType.FindAsync(id);

            if (taskType == null)
            {
                return NotFound();
            }

            return taskType;
        }

        // PUT: api/TaskTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        [Route("TaskTypes/Index")]
        public async Task<IActionResult> PutTaskType(int id, TaskType taskType)
        {
            if (id != taskType.TaskTypeId)
            {
                return BadRequest();
            }

            _context.Entry(taskType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTypeExists(id))
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

        // POST: api/TaskTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<TaskType>> PostTaskType(TaskType taskType)
        {
            _context.TaskType.Add(taskType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskType", new { id = taskType.TaskTypeId }, taskType);
        }

        // DELETE: api/TaskTypes/5
        [HttpDelete("{id}")]
        [Route("TaskTypes/DeleteTaskType/{id}")]
        public async Task<IActionResult> DeleteTaskType(int id)
        {
            var taskType = await _context.TaskType.FindAsync(id);
            if (taskType == null)
            {
                return NotFound();
            }

            _context.TaskType.Remove(taskType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskTypeExists(int id)
        {
            return _context.TaskType.Any(e => e.TaskTypeId == id);
        }

        [HttpGet]
        [Route("[action]")]
        public dynamic GetTaskTypeDAL()
        {
            return _aDAL.GetAll();
        }
    }
}
