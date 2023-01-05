namespace BlazorApp.Models;

public class StudentValidation : AbstractValidator<Student>
{
    public StudentValidation()
    {
        RuleFor(s => s.Name).NotEmpty();
        RuleFor(s => s.Email).NotEmpty();
        RuleFor(s => s.Address).NotEmpty();
    }
}