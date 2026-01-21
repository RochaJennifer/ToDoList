using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Entities; 
using ToDoList.Data;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public ToDoListController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] string descricao)
    {
        var novaTarefa = new Tarefa 
        {  
            Descricao = descricao, 
            Concluida = false 
        };
        
        _context.Tarefas.Add(novaTarefa);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), novaTarefa);
    }

    [HttpGet]
    public async Task<ActionResult<List<Tarefa>>> Get()
    {
        return await _context.Tarefas.ToListAsync();
    }

    
    

    [HttpPut]
        public async Task<IActionResult> Put(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null) return NotFound("Tarefa não encontrada.");

        tarefa.Concluida = true;
        await _context.SaveChangesAsync();
        return Ok("Tarefa concluída com sucesso!");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null) return NotFound();

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        return Ok("Tarefa removida!");
    }
}