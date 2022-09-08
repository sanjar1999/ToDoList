using System.ComponentModel.DataAnnotations;
#pragma warning disable

namespace DAL.Models
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public DateTime DeadlineDate { get; set; }
        [Range( 0, 2 )]
        public Status Status { get; set; } = Status.NotStarted;
        public bool IsDeleted { get; set; }
    }

    public enum Status
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2
    }
}
