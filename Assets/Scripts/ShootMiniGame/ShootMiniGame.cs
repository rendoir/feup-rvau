using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMiniGame : MiniGame
{
    public override void OnPlayerEntered()
    {
        base.OnPlayerEntered();
    }

    public override void OnPlayerExited()
    {
        base.OnPlayerExited();
    }

    public void Update()
    {
        if(!isPlayerInside)
            return;
    }
}
