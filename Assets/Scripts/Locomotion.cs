using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Locomotion : MonoBehaviour
{
    public float m_Sensitivity = 0.1f;
    public float m_MaxSpeed = 1.0f;
    public float m_Velocity = 10f;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private Vector2 m_Speed = Vector2.zero;

    private Transform m_CameraRig = null;
    private Transform m_Head = null;
    public Rigidbody m_RigidBody;

    void Start()
    {
        m_CameraRig = SteamVR_Render.Top().origin;
        m_Head = SteamVR_Render.Top().head;
    }

    void FixedUpdate()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        if(m_Head == null || m_CameraRig == null)
            return;

        // Figure out movement orientation
        Vector3 orientationEuler = new Vector3(0, m_Head.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        // If not moving
        if (m_MovePress.GetLastStateUp(SteamVR_Input_Sources.Any))
            m_Speed = Vector2.zero;

        // If button pressed
           if(m_MovePress.state)
        {
            // Add and clamp
            m_Speed += new Vector2(m_MoveValue.axis.x, m_MoveValue.axis.y) * m_Sensitivity;
            m_Speed = Vector2.ClampMagnitude(m_Speed, m_MaxSpeed);

            // Orientation
            movement += orientation * (m_Speed.y * Vector3.forward + m_Speed.x * Vector3.right);
        }

        // Apply
        m_RigidBody.velocity = movement * m_Velocity * Time.deltaTime;
    }

    public void StopMoving()
    {
        m_RigidBody.velocity = Vector3.zero;
    }
}
