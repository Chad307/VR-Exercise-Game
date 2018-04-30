using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

namespace Player
{
    public class PunchTracker : MonoBehaviour
    {
        //SteamVR_TrackedObject trackedObject;

        //SteamVR_TrackedController trackedController;

        public Hand hand;

        public float forceMultipler;

        //SteamVR_Controller.Device device;

        // Use this for initialization
        void Awake()
        {
            //trackedObject = GetComponent<SteamVR_TrackedObject>();
            //trackedController = GetComponent<SteamVR_TrackedController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("projectile") && other.GetComponent<Move>().isPunchable)
            {
                other.GetComponent<Move>().StartDetonation(false);
                Rigidbody projectileRigidbody = other.GetComponent<Rigidbody>();
                projectileRigidbody.velocity = hand.GetTrackedObjectVelocity() * forceMultipler;
                projectileRigidbody.angularVelocity = hand.GetTrackedObjectAngularVelocity() * forceMultipler;
                projectileRigidbody.maxAngularVelocity = projectileRigidbody
                    .angularVelocity.magnitude;
            }
        }
    }
}
