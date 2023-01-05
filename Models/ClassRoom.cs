namespace BlazorApp.Models;

public class ClassRoom : BaseEntity
{
    public ClassRoom()
    {
        Students = new List<Student>();
        Teachers = new List<Teacher>();
    }

    public string ClassName { get; set; }

    public Demo Demo { get; set; }

    public ICollection<Student> Students { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
}

public class Demo : BaseEntity
{
    public string String1 { get; set; }
    public string String2 { get; set; }
}