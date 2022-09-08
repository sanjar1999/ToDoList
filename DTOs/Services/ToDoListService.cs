using DAL;
using DAL.Models;
using DTOs.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable

namespace DTOs.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly ApplicationContext _db;
        public ToDoListService( ApplicationContext db )
        {
            _db = db;
        }

        public async Task ChangeStatus( int id, ChangeStatusDTO status )
        {
            try
            {
                var todoUpdate = await _db.ToDoLists.Where( x => x.Id == id ).FirstOrDefaultAsync();

                if ( todoUpdate == null )
                {
                    throw new ArgumentNullException( nameof( todoUpdate ) );
                }

                todoUpdate.Status = status.Status;

                await _db.SaveChangesAsync();
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

        public async Task CreateToDo( ToDoListDTO todoDTO )
        {
            try
            {
                if ( todoDTO == null )
                {
                    throw new ArgumentNullException( nameof( todoDTO ) );
                }
                var res = new ToDoList
                {
                    Id = todoDTO.Id,
                    Title = todoDTO.Title,
                    Description = todoDTO.Description,
                    DateOfCreation = todoDTO.DateOfCreation,
                    DeadlineDate = todoDTO.DateOfCreation.AddDays( 7 ),
                    Status = todoDTO.Status
                };

                await _db.AddAsync( res );
                await _db.SaveChangesAsync();
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

        public async Task DeleteToDo( int id )
        {
            try
            {
                if ( id == null )
                {
                    throw new ArgumentNullException( nameof( id ) );
                }

                var res = await _db.ToDoLists.Where( x => x.Id == id ).FirstOrDefaultAsync();

                if ( res.IsDeleted == false )
                {
                    res.IsDeleted = true;
                    await _db.SaveChangesAsync();
                }
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

        public async Task<List<ToDoListDTO>> GetByStatus( Status status )
        {
            try
            {
                var res = await _db.ToDoLists.Where( x => x.Status == status && x.IsDeleted == false)
                                             .Select( y => new ToDoListDTO
                                             {
                                                 Id = y.Id,
                                                 Title = y.Title,
                                                 Description = y.Description,
                                                 DateOfCreation = y.DateOfCreation,
                                                 DeadlineDate = y.DeadlineDate,
                                                 Status = y.Status
                                             } ).ToListAsync();

                return res;
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

        public async Task<ToDoListDTO> GetToDo( int id )
        {
            try
            {
                var res = await _db.ToDoLists.Where( x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();

                if ( res == null )
                {
                    throw new ArgumentNullException( nameof( res ) );
                }

                var todo = new ToDoListDTO
                {
                    Id = res.Id,
                    Title = res.Title,
                    Description = res.Description,
                    DateOfCreation = res.DateOfCreation,
                    DeadlineDate = res.DeadlineDate,
                    Status = res.Status,
                };

                return todo;
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

        public async Task<List<ToDoListDTO>> GetToDoList()
        {
            try
            {
                var res = await _db.ToDoLists.Where(y => y.IsDeleted == false)
                                             .Select( x => new ToDoListDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    DateOfCreation = x.DateOfCreation,
                    DeadlineDate = x.DeadlineDate,
                    Status = x.Status
                } ).ToListAsync();

                return res;
            }
            catch ( Exception e )
            {
                throw new ArgumentNullException( nameof( e ) );
            }
        }

        public async Task UpdateToDo( int id, ToDoListDTO dto )
        {
            try
            {
                var todoUpdate = await _db.ToDoLists.Where( x => x.Id == id ).FirstOrDefaultAsync();

                if ( todoUpdate == null )
                {
                    throw new ArgumentNullException( nameof( todoUpdate ) );
                }

                todoUpdate.Title = dto.Title;
                todoUpdate.Description = dto.Description;
                todoUpdate.DateOfCreation = dto.DateOfCreation;
                todoUpdate.DeadlineDate = dto.DeadlineDate;
                todoUpdate.Status = dto.Status;

                await _db.SaveChangesAsync();
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }
    }
}
