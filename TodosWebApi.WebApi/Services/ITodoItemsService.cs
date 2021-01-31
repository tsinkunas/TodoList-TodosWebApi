using System.Collections.Generic;
using System.Threading.Tasks;
using TodosWebApi.WebApi.Dtos;
using TodosWebApi.WebApi.Entities;

namespace TodosWebApi.WebApi.Services
{
    public interface ITodoItemsService
    {
        Task<List<TodoItem>> Get();

        Task<TodoDto> Create(TodoDto item);

        Task Completed(TodoItem item);

        Task<TodoItem> Delete(int id);
        
    }
}