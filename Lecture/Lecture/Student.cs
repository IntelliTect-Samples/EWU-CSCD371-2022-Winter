namespace Lecture;
public record class Student : Person
{
    // This is bad design used for simplicity (don't do this at home) :)
    public Grade Grade { get; set; }
    public Student(string name):base(name)
    {
        
    }
}
