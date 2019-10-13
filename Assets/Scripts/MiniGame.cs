using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public bool isPlayerInside = false;
    public bool isPlayerPlaying = false;

    public virtual void OnPlayerEntered()
    {
        isPlayerInside = true;
    }

    public virtual void OnPlayerExited()
    {
        isPlayerInside = false;
        isPlayerPlaying = false;
    }
}
