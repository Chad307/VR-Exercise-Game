using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Move : MonoBehaviour {

    public Transform target;
    public float speed;
    public float detonationTime;
    public GameObject detonationPrefab;
    public bool isPunchable;

    private ReferenceManager reference;

	// Use this for initialization
	void Awake () {
        reference = FindObjectOfType<ReferenceManager>();
        target = reference.target;
        GetComponent<Rigidbody>().AddForce((target.position - transform.position) * speed, 
            ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () {
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}

    public void StartDetonation(bool gameOver)
    {
        GameObject explosion = Instantiate(detonationPrefab, transform);
        explosion.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        StartCoroutine(Detonate(gameOver));
    }

    private IEnumerator Detonate(bool gameOver)
    {
        yield return new WaitForSeconds(detonationTime);
        if (!gameOver)
        {
            reference.score.AddScore();
        }
        Destroy(gameObject);
    }
}
