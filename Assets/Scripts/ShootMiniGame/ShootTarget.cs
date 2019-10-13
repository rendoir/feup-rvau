using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{
    public ShootRow row;
    public LayerMask rowEndColliderLayer;
    public LayerMask bulletLayer;
    public Vector3 speed;

    void Update()
    {
        transform.position += speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision) {
        if(Utils.MaskContainsLayer(bulletLayer, collision.gameObject.layer))
            OnBulletHit();
    }

    void OnTriggerEnter(Collider other) {
        if(Utils.MaskContainsLayer(rowEndColliderLayer, other.gameObject.layer))
            Restart();
    }

    void OnBulletHit() {
        
    }

    void Restart() {
        transform.position = row.startTransform.position;
    }
}
