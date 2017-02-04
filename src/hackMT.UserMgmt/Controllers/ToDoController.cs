using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackMT.UserMgmt.Controllers
{
    public class ToDoController : Controller
    {
        static List<TodoItem> toDoItems = new List<TodoItem>();
        TodoRepository repo = new TodoRepository();
        [HttpGet()]
        [Route("api/todo/items")]
        public List<TodoItem> GetAll()
        {
            return repo.GetAllItems();
        }

        [HttpPost()]
        [Route("api/todo/item")]
        public int Post([FromBody] TodoItem newTodo)
        {
            if (newTodo != null)
            {
                return repo.AddItem(newTodo);
            }
            return -1;
        }

        [HttpPut()]
        [Route("api/todo/{id}")]
        public int Put(int id, [FromBody] TodoItem itemToUpdate)
        {
            return repo.UpdateItem(id, itemToUpdate);
        }

        [HttpDelete()]
        [Route("api/todo/{id}")]
        public bool Delete(int id)
        {
            bool isDeleteSuccessful = false;
            try
            {
                repo.DeleteItem(id);
                isDeleteSuccessful = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
            return isDeleteSuccessful;
        }
    }
}
