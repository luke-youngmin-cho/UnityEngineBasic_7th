using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    protected override void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        base.Update();
    }
}
