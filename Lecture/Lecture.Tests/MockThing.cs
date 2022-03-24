namespace Lecture.Tests;
internal class MockThing : ISavable
{
    public string Name { get; set; }

    public MockThing(string name)
    {
        Name=name;
    }

    public string ToText()
    {
        return $"{nameof(Name)}: {Name}";
    }
}

