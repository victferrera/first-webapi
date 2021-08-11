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
        public JsonResult Get()
        {
            var itens = _context.TodoItem.ToList();
            return Json(itens);

        }

        [HttpPost]
        public TodoItem Create(TodoItem todo)
        {
            _context.Add(todo);
            _context.SaveChanges();

            return todo;
        }

    }
}
