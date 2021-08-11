using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Models
{
    public class TodoItem
    {
        [Key]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "IsComplete is required")]
        public bool IsCompleted { get; set; }

        public TodoItem(){ }

        public TodoItem(int? id, string name, bool isCompleted)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
        }
    }
}
