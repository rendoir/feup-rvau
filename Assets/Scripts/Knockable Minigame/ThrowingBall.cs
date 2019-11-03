using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class ThrowingBall : Throwable
    {
        protected bool WasUsed = false;

        public delegate void OnNotUsableEventDelegate();
        List<OnNotUsableEventDelegate> OnNotUsableListeners = new List<OnNotUsableEventDelegate>();

        public float SpeedThreshold = 0.025f;
        private Vector3 PreviousVelocity = Vector3.zero;
        private bool hasBeenDetatched = false;
        private Rigidbody Rigidbody;
        private bool detectedAsDepleted = false;

        void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

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
            this.hasBeenDetatched = true;
        }

        void FixedUpdate()
        {
            if (hasBeenDetatched && !detectedAsDepleted)
            {
                float velocityDelta = Mathf.Abs(Vector3.Distance(this.PreviousVelocity, this.Rigidbody.velocity));
                if (velocityDelta < SpeedThreshold)
                {
                    detectedAsDepleted = true;
                    foreach (OnNotUsableEventDelegate handler in OnNotUsableListeners)
                    {
                        handler();
                    }
                }
                else
                {
                    this.PreviousVelocity.x = this.Rigidbody.velocity.x;
                    this.PreviousVelocity.y = this.Rigidbody.velocity.y;
                    this.PreviousVelocity.z = this.Rigidbody.velocity.z;
                }
            }
        }

        public void RegisterOnNotUsableListener(OnNotUsableEventDelegate handler)
        {
            OnNotUsableListeners.Add(handler);
        }

    }
}