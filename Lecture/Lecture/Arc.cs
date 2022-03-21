namespace Lecture;

public record struct Arc
{
    public Arc(int startAngle, int sweeepAngle)
    {
        StartAngle = startAngle;
        SweepAngle = sweeepAngle;
    }
    public int StartAngle { get; }
    public int SweepAngle { get;  }


    // Don't do this!!!!
    //public void ZeroOut()
    //{
    //    Angle = 0;
    //}
}
