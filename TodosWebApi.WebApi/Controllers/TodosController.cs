using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodosWebApi.WebApi.Dtos;
using TodosWebApi.WebApi.Entities;
using TodosWebApi.WebApi.Services;

namespace TodosWebApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController
    {
        
        private readonly ITodoItemsService _todoItemsService;

        public TodosController(ITodoItemsService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _todoItemsService.Get();
        }

        [HttpPost]
        public async Task<TodoDto> Create(TodoDto item)
        {
            return await _todoItemsService.Create(item);
        }

        [HttpPut("{id}")]
        public async Task Completed(TodoItem item)
        {
            await _todoItemsService.Completed(item);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _todoItemsService.Delete(id);
        }


    }
}
