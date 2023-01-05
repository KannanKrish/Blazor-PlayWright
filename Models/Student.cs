namespace BlazorApp.Models;

public partial class Student : BaseEntity
{
    [Encrypted] public string Name { get; set; }
    [Encrypted] public string Email { get; set; }
    [Encrypted] public string Address { get; set; }
    public List<string> PhoneNumbers { get; set; }
    public Uri Url { get; set; }
    public StudentType StudentType { get; set; }
    [DateFilter(30)] public DateTime AcademicYear { get; set; }
}