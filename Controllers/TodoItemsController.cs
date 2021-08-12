using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstWebApi.Context;
using FirstWebApi.Models;
using Newtonsoft;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : Controller
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var itens = await _context.TodoItem.ToListAsync();
            return Json(itens);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetByIdAsync(int id)
        {
            var todo = await _context.TodoItem.FindAsync(id);

            if (todo == null)
                return Json("Data not found on database");

            return Json(todo);
        }

        [HttpPost]
        public async Task<TodoItem> CreateAsync(TodoItem todo)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        [HttpPut("{id}")]
        public async Task<JsonResult> UpdateAsync(int id, TodoItem todo)
        {
            var obj = _context.TodoItem.Find(id);

            if (obj == null)
                return Json("Data not found on database");

            obj.Name = todo.Name;
            obj.IsCompleted = todo.IsCompleted;

            _context.Update(obj);
            await _context.SaveChangesAsync();

            return Json(obj);
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteAsync(int id)
        {
            var todo = _context.TodoItem.Find(id);

            if (todo == null)
                return Json("Data not found on database");

            _context.Remove(todo);
            await _context.SaveChangesAsync();

            return Json(todo);
        }

    }
}
