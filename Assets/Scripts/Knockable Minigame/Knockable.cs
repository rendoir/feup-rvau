using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockable : MonoBehaviour
{
    public float deltaE = 5;

    private Quaternion initialQuarternion;
    private Renderer objectRenderer;

    public delegate void NotifyOnKnockdownDelegate();

    List<NotifyOnKnockdownDelegate> registeredDelegates = new List<NotifyOnKnockdownDelegate>();

    private bool KnockedDown = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        initialQuarternion = this.gameObject.transform.rotation;
    }
    void FixedUpdate()
    {
        if (!KnockedDown)
        {
            Quaternion currentRotations = this.gameObject.transform.rotation;
            float delta = Quaternion.Angle(currentRotations, initialQuarternion);
            if (delta >= deltaE)
            {
                objectRenderer.material.SetColor("_Color", Color.red);
                foreach (NotifyOnKnockdownDelegate handler in registeredDelegates)
                {
                    KnockedDown = true;
                    handler();
                }
            }
        }
    }

    public void RegisterDelegate(NotifyOnKnockdownDelegate handler)
    {
        registeredDelegates.Add(handler);
    }
}
