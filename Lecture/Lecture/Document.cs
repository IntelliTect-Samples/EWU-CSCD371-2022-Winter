using System.Runtime.Serialization;

namespace Lecture;
public class Document : Thing, ISavable, ISerializable
{
    public string? Content { get; private set; }

    public Document(string name)
        :base(name)=> Name = name;

    public override string ToText() => $"{nameof(Name)}: {Name}, {nameof(Content)}: {Content}";

    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }
}