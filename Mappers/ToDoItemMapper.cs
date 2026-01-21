using ToDoListApi.Dtos;
using ToDoListApi.Models;

namespace ToDoListApi.Mappers;

public static class ToDoItemMapper
{
    public static ToDoItemDto ToDto(this ToDoItem item)
        => new(item.Id, item.Title, item.IsCompleted);

    public static ToDoItem FromCreateDto(this CreateToDoItemDto dto)
        => new() { Title = dto.Title, IsCompleted = false };

    public static void UpdateFromDto(this ToDoItem item, UpdateToDoItemDto dto)
    {
        if (dto.Title != null)
            item.Title = dto.Title;
        if (dto.IsCompleted.HasValue)
            item.IsCompleted = dto.IsCompleted.Value;
    }
}
