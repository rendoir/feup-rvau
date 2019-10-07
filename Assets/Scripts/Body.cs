using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(CapsuleCollider))]
public class Body : MonoBehaviour
{
    public Transform head;

    private CapsuleCollider capsuleCollider;

    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        head = SteamVR_Render.Top().head;
    }


    void FixedUpdate()
    {
        float distanceFromFloor = Vector3.Dot(head.localPosition, Vector3.up);
        capsuleCollider.height = distanceFromFloor - capsuleCollider.radius * 2;
        transform.localPosition = head.localPosition - distanceFromFloor * Vector3.up;
        capsuleCollider.center = new Vector3(0, distanceFromFloor / 2, 0);
    }
}
