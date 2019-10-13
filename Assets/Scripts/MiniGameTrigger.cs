using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public MiniGame miniGame;
    public LayerMask playerLayer; 
    
    void OnTriggerEnter(Collider other)
    {
        if(Utils.MaskContainsLayer(playerLayer, other.gameObject.layer))
            miniGame.OnPlayerEntered();
    }

    void OnTriggerExit(Collider other)
    {
        if(Utils.MaskContainsLayer(playerLayer, other.gameObject.layer))
            miniGame.OnPlayerExited();
    }
}
