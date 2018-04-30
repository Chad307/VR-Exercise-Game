using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

namespace Player
{
    public class PunchTracker : MonoBehaviour
    {
        public Hand hand;

        public float forceMultipler;

        public float minimumHandVelocity = 0.8f;

        // Use this for initialization
        void Awake()
        {
            //trackedObject = GetComponent<SteamVR_TrackedObject>();
            //trackedController = GetComponent<SteamVR_TrackedController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("projectile") && other.GetComponent<Move>().isPunchable
                && hand.GetTrackedObjectVelocity().sqrMagnitude >= minimumHandVelocity)
            {
                other.GetComponent<Move>().StartDetonation(false);
                Rigidbody projectileRigidbody = other.GetComponent<Rigidbody>();
                projectileRigidbody.velocity = hand.GetTrackedObjectVelocity() * forceMultipler;
                projectileRigidbody.angularVelocity = hand.GetTrackedObjectAngularVelocity() * forceMultipler;
                projectileRigidbody.maxAngularVelocity = projectileRigidbody
                    .angularVelocity.magnitude;
                Debug.Log(hand.GetTrackedObjectVelocity().sqrMagnitude);
            }
        }
    }
}
