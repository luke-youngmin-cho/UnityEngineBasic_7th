using System;

public interface IState<T> where T : Enum
{
    public enum Step
    {
        None,
        Start,
        Casting,
        OnAction,
        Finish
    }
    Step step { get; }
    T MoveNext();
    void Reset();
}
