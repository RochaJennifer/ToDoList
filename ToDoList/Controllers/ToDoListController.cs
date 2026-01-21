using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities; 

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListController : ControllerBase
{
    private static List<Tarefa> _tarefas = new List<Tarefa>();
    private static int _proximoId = 1;

    [HttpGet]
    public ActionResult<List<Tarefa>> Get()
    {
        return Ok(_tarefas);
    }

    
    [HttpPost]
    public ActionResult Post([FromBody] string descricao)
    {
        var novaTarefa = new Tarefa 
        { 
            Id = _proximoId++, 
            Descricao = descricao, 
            Concluida = false 
        };
        
        _tarefas.Add(novaTarefa);
        return CreatedAtAction(nameof(Get), novaTarefa);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return NotFound("Tarefa não encontrada.");

        tarefa.Concluida = true;
        return Ok("Tarefa concluída com sucesso!");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return NotFound();

        _tarefas.Remove(tarefa);
        return Ok("Tarefa removida!");
    }
}