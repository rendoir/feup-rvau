using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class ThrowingBall : Throwable
    {
        protected bool wasAttached = false;

        protected override void HandHoverUpdate(Hand hand)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();

            if (startingGrabType != GrabTypes.None && !wasAttached)
            {
                hand.AttachObject(gameObject, startingGrabType, attachmentFlags, attachmentOffset);
                hand.HideGrabHint();
                wasAttached = true;
                GetComponent<Interactable>().highlightOnHover = false;
            }
        }

    }
}