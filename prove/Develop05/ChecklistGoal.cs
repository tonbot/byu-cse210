[Serializable]
class ChecklistGoal : Goal
{
    public int CompletionCount { get; set; }

    public override void RecordEvent()
    {
        CurrentValue += Value;
        if (CurrentValue % Value == 0)
        {
            CompletionCount++;
        }
    }

    public override bool IsComplete()
    {
        return CompletionCount >= Value / CurrentValue;
    }

    public override string GetProgressString()
    {
        return $"Completed {CompletionCount}/{Value / CurrentValue} times";
    }
}
