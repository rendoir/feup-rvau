using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float lifetime = 2.5f;
    public static float force = 1000;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }
}
