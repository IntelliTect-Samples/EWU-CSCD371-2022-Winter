namespace Lecture;

public abstract class AThing : ISavable
{
    public abstract string Name { get; set; }

    protected AThing(string name)
    {
        Name=name;
    }

    public string ToText()
    {
        return $"{nameof(Name)}: {Name}";
    }
}

