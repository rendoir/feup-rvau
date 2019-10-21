using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{
    public ShootRow row;
    public LayerMask rowEndColliderLayer;
    public LayerMask bulletLayer;
    public bool hit;

    void Start()
    {
        Restart();
    }
    
    void Update()
    {
        transform.position += row.speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision) {
        if(Utils.MaskContainsLayer(bulletLayer, collision.gameObject.layer))
            OnBulletHit();
    }

    void OnTriggerEnter(Collider other) {
        if(Utils.MaskContainsLayer(rowEndColliderLayer, other.gameObject.layer))
            OnRowEnd();
    }

    void OnBulletHit() {
        if(!hit) {
            hit = true;
            row.shootMiniGame.OnTargetHit();
        }
    }

    void OnRowEnd() {
        transform.position = row.startTransform.position;
    }

    public void Restart() {
        hit = false;
    }
}
