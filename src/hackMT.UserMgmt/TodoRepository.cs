using System.Linq;
using System.Collections.Generic;
using hackMT.UserMgmt;

public class TodoRepository
{
    public TodoRepository()
    {

    }
    public int AddItem(TodoItem newTodo)
    {
        int itemIndex;
        using (TodoDbContext context = new TodoDbContext())
        {
            context.TodoItems.Add(newTodo);
            context.SaveChanges();
            itemIndex = context.TodoItems.ToList().IndexOf(newTodo);
        }
        return itemIndex;
    }
    public List<TodoItem> GetAllItems()
    {
        using (TodoDbContext context = new TodoDbContext())
        {
            return context.TodoItems.ToList();
        }
    }
    public int UpdateItem(int index, TodoItem itemToUpdate)
    {
        using (TodoDbContext context = new TodoDbContext())
        {
            var updatingItem = context.TodoItems.Where(item => item.TodoId == index).FirstOrDefault();
            updatingItem.Description = itemToUpdate.Description;
            updatingItem.DueDate = itemToUpdate.DueDate;
            context.SaveChanges();
            return index;
        }
    }
    public bool DeleteItem(int index)
    {
        using (var context = new TodoDbContext())
        {
            var itemToRemove = context.TodoItems.ToList()[index];
            context.TodoItems.Remove(itemToRemove);
            context.SaveChanges();
            return true;
        }
    }
}