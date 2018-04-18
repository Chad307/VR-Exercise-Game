using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPos;

    public GameObject blue;

    public GameObject red;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

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
