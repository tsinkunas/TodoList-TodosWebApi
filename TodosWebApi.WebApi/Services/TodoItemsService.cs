using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TodosWebApi.WebApi.Data;
using TodosWebApi.WebApi.Dtos;
using TodosWebApi.WebApi.Entities;

namespace TodosWebApi.WebApi.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly DataContext _context;

        public TodoItemsService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> Get()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<TodoDto> Create(TodoDto item)
        {
            _context.Items.Add(new TodoItem()
            {
                Title = item.Title,
                Completed = item.Completed
            });

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task Completed(TodoItem item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> Delete(int id)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();

            TodoItem item = await _context.Items.FindAsync(id);

            try
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                returnMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, ex.ToString());
            }

            return item;
        }

    }
}
