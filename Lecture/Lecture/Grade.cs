namespace Lecture;

public enum Grade : int
{
    None,
    F = 1,
    D,
    C,
    B,
    A,
}


[Flags]
public enum FileAttributes : int
{
    None,
    Hidden,
    ReadOnly,
    System = Hidden | ReadOnly
}
