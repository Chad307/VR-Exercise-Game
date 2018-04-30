using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace Player
{
    public class Head : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("projectile") && !other.GetComponent<Move>().isPunchable)
            {
                Debug.Log("Head hit");
                FindObjectOfType<ReferenceManager>().spawner.Stop();
            }
        }
    }
}
