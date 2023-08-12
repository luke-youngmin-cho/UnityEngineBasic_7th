using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    Success,
    Failure,
}

public abstract class Node
{
    public abstract Status Invoke();
}
