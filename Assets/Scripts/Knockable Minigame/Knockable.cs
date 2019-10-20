using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockable : MonoBehaviour
{
    public float deltaE = 5;

    private Quaternion initialQuarternion;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        initialQuarternion = this.gameObject.transform.rotation;
    }
    void FixedUpdate()
    {
        Quaternion currentRotations = this.gameObject.transform.rotation;
        float delta = Quaternion.Angle(currentRotations, initialQuarternion);
        if(delta >= deltaE)
        {
            objectRenderer.material.SetColor("_Color",Color.red);
        }
    }
}
