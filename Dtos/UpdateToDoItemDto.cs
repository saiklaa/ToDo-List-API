namespace ToDoListApi.Dtos;
public record UpdateToDoItemDto(string? Title = null, bool? IsCompleted = null);
