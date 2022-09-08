using DAL.Models;
using DTOs.Models;

namespace DTOs.Services
{
    public interface IToDoListService
    {
        Task<List<ToDoListDTO>> GetToDoList();
        Task<List<ToDoListDTO>> GetByStatus( Status status );
        Task ChangeStatus( int id, ChangeStatusDTO status );
        Task CreateToDo( ToDoListDTO dto );
        Task<ToDoListDTO> GetToDo( int id );
        Task UpdateToDo( int id, ToDoListDTO dto );
        Task DeleteToDo( int id );
    }
}
