using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApp.Models
{
    public class ToDoItem
    {
        [Key] // Tells EF Core this is our primary key matching the MySQL AUTO_INCREMENT Id
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        // In MySQL, this maps cleanly to a TINYINT(1) column
        public bool IsDone { get; set; }

        [NotMapped] // Tells EF Core to ignore this property; it's only used for UI state toggling
        public bool IsEditing { get; set; } = false;
    }
}