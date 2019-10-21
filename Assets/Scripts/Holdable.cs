using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{
	public class Holdable : Throwable
	{
        [System.Serializable]
        public class HoldableEvent : UnityEvent<Hand, Holdable> { }

        public HoldableEvent onAttachToHand;

        // Deletes release grabing logic
        protected override void HandAttachedUpdate(Hand hand)
        {
            /*
            // Release when the trigger is pressed again after attaching
            GrabTypes startingGrabType = hand.GetGrabStarting();
            
            if (startingGrabType != GrabTypes.None)
				hand.DetachObject( gameObject, restoreOriginalParent );
            */
        }

        public void DetachFromHand(Hand hand) 
        {
            hand.DetachObject( gameObject, restoreOriginalParent );
        }

        // Same as base class but calls an event with the hand as argument
        protected override void OnAttachedToHand( Hand hand )
		{
            hadInterpolation = this.rigidbody.interpolation;

            attached = true;

			onAttachToHand.Invoke(hand, this);
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.rotation = Quaternion.Euler(Vector3.zero);

            hand.HoverLock( null );
            
            rigidbody.interpolation = RigidbodyInterpolation.None;
            
		    velocityEstimator.BeginEstimatingVelocity();

			attachTime = Time.time;
			attachPosition = transform.position;
			attachRotation = transform.rotation;
		}
	}
}
