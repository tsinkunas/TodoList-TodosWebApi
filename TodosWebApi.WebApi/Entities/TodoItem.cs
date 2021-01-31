﻿namespace TodosWebApi.WebApi.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; } = false;
    }
}
