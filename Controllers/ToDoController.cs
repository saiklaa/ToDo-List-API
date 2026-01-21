using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Dtos;
using ToDoListApi.Models;
using ToDoListApi.Services;

namespace ToDoListApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly ToDoService _service;

    public ToDoController(ToDoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ToDoItemDto>> GetAll() => _service.GetAll();

    [HttpGet("{id}")]
    public ActionResult<ToDoItemDto> GetById(int id)
    {
        var item = _service.GetById(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public ActionResult<ToDoItemDto> Create([FromBody] CreateToDoItemDto dto)
    {
        var item = _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateToDoItemDto dto)
    {
        var success = _service.Update(id, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = _service.Delete(id);
        return success ? NoContent() : NotFound();
    }
}
