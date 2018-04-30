using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public Transform target;
    public float speed;
    public float detonationTime;
    public GameObject detonationPrefab;

	// Use this for initialization
	void Awake () {
        GetComponent<Rigidbody>().AddForce((target.position - transform.position) * speed, 
            ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}

    public void StartDetonation()
    {
        Instantiate(detonationPrefab, transform);
        StartCoroutine(Detonate());
    }

    private IEnumerator Detonate()
    {
        yield return new WaitForSeconds(detonationTime);
        Destroy(gameObject);
    }
}
