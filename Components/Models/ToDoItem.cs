namespace ToDoListApp.Models
{
    public class ToDoItem
    {
        public string Title { get; set; } = "";
        public bool IsDone { get; set; }
        public bool IsEditing { get; set; }
    }
}