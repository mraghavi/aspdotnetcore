using Microsoft.AspNetCore.Mvc;

namespace CrudAppBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : Controller
{
    private static List<Todo> Todos = new List<Todo>
    {
        new Todo { Id = 1, Title = "Learn .NET", IsCompleted = false },
        new Todo { Id = 2, Title = "Build a Todo App", IsCompleted = false }
    };

    [HttpGet]
    public IActionResult GetTodos() => Ok(Todos);

    [HttpPost]
    public IActionResult CreateTodo([FromBody] Todo newTodo)
    {
        newTodo.Id = Todos.Any() ? Todos.Max(t => t.Id) + 1 : 1;
        Todos.Add(newTodo);
        return CreatedAtAction(nameof(GetTodos), new { id = newTodo.Id }, newTodo);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTodo(int id, [FromBody] Todo updatedTodo)
    {
        var todo = Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null) return NotFound();

        todo.Title = updatedTodo.Title;
        todo.IsCompleted = updatedTodo.IsCompleted;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodo(int id)
    {
        var todo = Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null) return NotFound();

        Todos.Remove(todo);
        return NoContent();
    }
}

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}
