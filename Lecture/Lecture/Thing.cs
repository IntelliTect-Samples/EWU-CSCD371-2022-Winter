namespace Lecture;

public class Thing : ISavable
{
    public virtual string Name { get; set; }

    public Thing(string name)
    {
        Name=name;
    }

    public virtual string ToText()
    {
        return $"{nameof(Name)}: {Name}";
    }
}

