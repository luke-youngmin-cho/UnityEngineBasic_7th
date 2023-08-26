using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUI
{
    int sortOrder { get; set; }

    event Action onShow;
    event Action onHide;

    void Show();
    void Hide();
}
