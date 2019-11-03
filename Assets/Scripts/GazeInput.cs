using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.Events;

public class GazeInput : MonoBehaviour
{
    public Image image;
    public Transform head = null;
    public LayerMask layer;
    public float fillSpeed = 10f;
    public float maxDistance = 100f;
    public float imageOffset = 0.001f;
    public float distanceScale = 0.25f;

    public UnityEvent OnGazeComplete;

    private bool canIncrement;

    void Start()
    {
        //head = SteamVR_Render.Top().head;

        canIncrement = true;
    }

    void Update()
    {
        CheckGaze();
    }

    void CheckGaze()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(head.position, head.forward, out hitInfo, maxDistance, layer, QueryTriggerInteraction.Collide)) {
            if(canIncrement) {
                image.rectTransform.position = hitInfo.point - head.forward * imageOffset;
                image.rectTransform.rotation = Quaternion.LookRotation(head.forward);
                image.rectTransform.localScale = new Vector3(hitInfo.distance * distanceScale, hitInfo.distance * distanceScale, 1);
                image.fillAmount += fillSpeed * Time.deltaTime;

                if(image.fillAmount >= 1) {
                    canIncrement = false;
                    image.fillAmount = 0f;
                    OnGazeComplete.Invoke();
                }
            }
        } else {
            canIncrement = true;
            image.fillAmount = 0f;
        }
    }    
}
