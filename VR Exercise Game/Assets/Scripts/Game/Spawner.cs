using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Menus;
using Valve.VR.InteractionSystem;

namespace Game
{
    public class Spawner : MonoBehaviour
    {

        public Transform[] spawnPos;

        public GameObject blue;

        public GameObject red;

        private ReferenceManager reference;

        private MenuTransitionManager menuTransitionManager;

        private Hand[] hands;

        private void Awake()
        {
            reference = FindObjectOfType<ReferenceManager>();
            menuTransitionManager = reference.menuTransitionManager;
            hands = reference.hands;
        }

        // Use this for initialization
        void OnEnable()
        {
            StartCoroutine(Spawn());
            reference.score.StartGameScore();
        }

        // Update is called once per frame
        void Update()
        {
            foreach (Hand hand in hands)
            {
                if (hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
                {
                    Stop();
                }
            }
        }

        public void Stop()
        {
            foreach (Move move in FindObjectsOfType<Move>())
            {
                move.StartDetonation(true);
            }
            foreach (UIPointer uiPointer in reference.uiPointers)
            {
                uiPointer.gameObject.SetActive(true);
            }

            menuTransitionManager.GoToMain();
            gameObject.SetActive(false);
        }

        public IEnumerator Spawn()
        {
            Transform placeToSpawn;
            GameObject toSpawn;
            float wait;
            while (true)
            {
                wait = Random.Range(1, 3);
                yield return new WaitForSeconds(wait);
                int randObject = Random.Range(0, 9);
                if (randObject == 0)
                {
                    toSpawn = red;
                }
                else
                {
                    toSpawn = blue;
                }
                int randPlacement = Random.Range(0, (spawnPos.Length - 1));

                placeToSpawn = spawnPos[randPlacement];
                Instantiate(toSpawn, placeToSpawn.position, transform.rotation);
            }

        }
    }
}
