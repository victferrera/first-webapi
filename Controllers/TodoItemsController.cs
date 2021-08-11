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

        [HttpPost]
        public async Task<TodoItem> CreateAsync(TodoItem todo)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        [HttpPut]
        public async Task<JsonResult> UpdateAsync(TodoItem todo)
        {
            if(todo.Id == null)
            {
                return Json("Id cannot be null");
            }

            var obj = _context.TodoItem.Find(todo.Id);

            obj.Name = todo.Name;
            obj.IsCompleted = todo.IsCompleted;

            _context.Update(obj);
            await _context.SaveChangesAsync();

            return Json(obj);
        }

    }
}
