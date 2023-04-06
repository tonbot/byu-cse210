class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int CurrentValue { get; set; }

    public virtual void RecordEvent()
    {
        CurrentValue += Value;
    }

    public virtual bool IsComplete()
    {
        return CurrentValue >= Value;
    }

    public virtual string GetProgressString()
    {
        return $"Completed {CurrentValue}/{Value} times";
    }
}
