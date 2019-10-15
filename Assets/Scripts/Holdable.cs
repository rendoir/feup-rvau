using UnityEngine;

namespace Valve.VR.InteractionSystem
{
	public class Holdable : Throwable
	{
        protected override void HandAttachedUpdate(Hand hand)
        {   
            /*
            GrabTypes startingGrabType = hand.GetGrabStarting();
            
            if (startingGrabType != GrabTypes.None)
				hand.DetachObject( gameObject, restoreOriginalParent );
            */
        }

        public void DetachFromHand(Hand hand) 
        {
            hand.DetachObject( gameObject, restoreOriginalParent );
        }
	}
}
