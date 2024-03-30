using System.ComponentModel.DataAnnotations;

namespace BloggingSite.Models
{
    public class AdminAction
    {
        [Key]
        public int ActionId { get; set; }

        public User Admin { get; set; } 

        public string? ActionType { get; set; }  //Removing Post , Deleting comment (or) Delete an user

        public string? ActionName { get; set; }

        public DateTime ActionDate { get; set; }
    }
}
