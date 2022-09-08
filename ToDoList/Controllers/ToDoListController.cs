using DAL.Models;
using DTOs.Models;
using DTOs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;
        public ToDoListController( IToDoListService toDoListService )
        {
            _toDoListService = toDoListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoList()
        {
            return Ok( await _toDoListService.GetToDoList() );
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo( ToDoListDTO toDoListDTO )
        {
            await _toDoListService.CreateToDo( toDoListDTO );
            return Ok();
        }

        [HttpDelete]
        [Route( "{id}" )]
        public async Task<IActionResult> DeleteToDo( int id )
        {
            await _toDoListService.DeleteToDo( id );
            return Ok();
        }

        [HttpPut]
        [Route( "{id}" )]
        public async Task<IActionResult> UpdateToDo( int id, ToDoListDTO toDoListDTO )
        {
            await _toDoListService.UpdateToDo( id, toDoListDTO );
            return Ok();
        }

        [HttpGet]
        [Route( "{id}" )]
        public async Task<IActionResult> GetToDoById( int id )
        {
            return Ok( await _toDoListService.GetToDo( id ) );
        }

        [HttpPut]
        [Route( "changeStatus/{id}" )]
        public async Task<IActionResult> ChangeStatus( int id, ChangeStatusDTO status )
        {
            await _toDoListService.ChangeStatus( id, status );
            return Ok();
        }

        [HttpGet]
        [Route( "status/{status}" )]
        public async Task<IActionResult> GetByStatus( Status status )
        {
            return Ok( await _toDoListService.GetByStatus( status ) );
        }
    }
}
