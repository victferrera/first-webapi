using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstWebApi.Context;
using FirstWebApi.Models;

namespace FirstWebApi.Controllers
{
    [Route("firstapi/v1/[controller]")]
    [ApiController]
    public class TodoItemsController : Controller
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna uma lista de TodoItem
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var itens = await _context.TodoItem.ToListAsync();
            return Json(itens);
        }

        /// <summary>
        /// Retorna um TodoItem pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<JsonResult> GetByIdAsync(int id)
        {
            var todo = await _context.TodoItem.FindAsync(id);

            if (todo == null)
                return Json("Data not found on database");

            return Json(todo);
        }

        /// <summary>
        /// Cria um novo TodoItem
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<TodoItem> CreateAsync(TodoItem todo)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        /// <summary>
        /// Atualiza um TodoItem pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<JsonResult> UpdateAsync(int id, TodoItem todo)
        {
            var obj = await _context.TodoItem.FindAsync(id);

            if (obj == null)
                return Json("Data not found on database");

            obj.Name = todo.Name;
            obj.IsCompleted = todo.IsCompleted;

            _context.Update(obj);
            await _context.SaveChangesAsync();

            return Json(obj);
        }

        /// <summary>
        /// Remove um TodoItem pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteAsync(int id)
        {
            var todo = await _context.TodoItem.FindAsync(id);

            if (todo == null)
                return Json("Data not found on database");

            _context.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(todo);
        }

    }
}
