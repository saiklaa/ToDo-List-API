using ToDoListApi.Dtos;
using ToDoListApi.Mappers;
using ToDoListApi.Models;

namespace ToDoListApi.Services;

public class ToDoService
{
    private readonly List<ToDoItem> _items = new();
    private int _nextId = 1;

    public List<ToDoItemDto> GetAll() => _items.Select(x => x.ToDto()).ToList();

    public ToDoItemDto? GetById(int id) => _items.FirstOrDefault(x => x.Id == id)?.ToDto();

    public ToDoItemDto Create(CreateToDoItemDto dto)
    {
        var item = dto.FromCreateDto();
        item.Id = _nextId++;
        _items.Add(item);
        return item.ToDto();
    }

    public bool Update(int id, UpdateToDoItemDto dto)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item == null) return false;

        item.UpdateFromDto(dto);
        return true;
    }

    public bool Delete(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        return item != null && _items.Remove(item);
    }
}
