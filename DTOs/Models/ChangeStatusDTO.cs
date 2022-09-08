using DAL.Models;

namespace DTOs.Models
{
    public class ChangeStatusDTO
    {
        public int Id { get; set; }
        public Status Status { get; set; } = Status.NotStarted;
    }
}
