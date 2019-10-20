using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class ThrowingBall : Throwable
    {
        protected bool WasUsed = false;

        public delegate void OnNotUsableEventDelegate();
        List<OnNotUsableEventDelegate> OnNotUsableListeners = new List<OnNotUsableEventDelegate>();

        protected override void HandHoverUpdate(Hand hand)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();

            if (startingGrabType != GrabTypes.None && !WasUsed)
            {
                hand.AttachObject(gameObject, startingGrabType, attachmentFlags, attachmentOffset);
                hand.HideGrabHint();
                WasUsed = true;
                GetComponent<Interactable>().highlightOnHover = false;
            }
        }

        protected override void OnDetachedFromHand(Hand hand)
        {
            base.OnDetachedFromHand(hand);
            foreach(OnNotUsableEventDelegate handler in OnNotUsableListeners)
            {
                handler();
            }
        }

        public void RegisterOnNotUsableListener(OnNotUsableEventDelegate handler)
        {
            OnNotUsableListeners.Add(handler);
        }

    }
}