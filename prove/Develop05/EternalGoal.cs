public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {}

    public override int RecordEvent()
    {
        return Points; // never complete
    }

    public override bool IsComplete() => false;

    public override string GetStatus()
    {
        return "[∞]";
    }

    public override string Serialize()
    {
        return $"Eternal|{Name}|{Description}|{Points}";
    }
}