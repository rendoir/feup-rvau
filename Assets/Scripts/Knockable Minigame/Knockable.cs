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

    private AudioSource canSound;

    void Start()
    {
        canSound = GetComponent<AudioSource>();
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

    void OnCollisionEnter(Collision collision)
    {
        Vector3 impulse = collision.impulse;
        float delay = Random.Range(0.001f, 0.005f);
        //canSound.volume = impulse.normalized.magnitude/Vector3.one.magnitude;
        canSound.PlayDelayed(delay);
    }

    public void RegisterDelegate(NotifyOnKnockdownDelegate handler)
    {
        registeredDelegates.Add(handler);
    }
}
