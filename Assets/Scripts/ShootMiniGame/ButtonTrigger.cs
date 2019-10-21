using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public LayerMask buttonLayer;
    public ShootMiniGame miniGame;

    void OnTriggerEnter(Collider other) {
        if(Utils.MaskContainsLayer(buttonLayer, other.gameObject.layer)) {
            miniGame.OnButtonPressed();
        }
    }
}
