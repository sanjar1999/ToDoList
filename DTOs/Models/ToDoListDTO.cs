using DAL.Models;
using System.ComponentModel.DataAnnotations;
#pragma warning disable

namespace DTOs.Models
{
    public class ToDoListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public DateTime DeadlineDate { get; set; }
        [Range( 0, 2 )]
        public Status Status { get; set; } = Status.NotStarted;
    }
}
