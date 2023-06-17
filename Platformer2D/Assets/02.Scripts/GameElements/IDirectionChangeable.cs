using System;

public interface IDirectionChangeable
{
    int direction { get; set; }
    event Action<int> onDirectionChanged;
}
