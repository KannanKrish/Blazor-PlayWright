namespace BlazorApp.Models;

public class Teacher : BaseEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}