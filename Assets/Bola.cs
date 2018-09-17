using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {

    float sx;
    float sy;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {

        sx = Random.Range(0, 2) == 0 ? -1 : 1;
        sy = Random.Range(0, 2) == 0 ? -1 : 1;


        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(Random.Range(5, 10) * sx, Random.Range(5, 10) * sy, 0);

    }
	
	// Update is called once per frame
	void Update () {


		
	}
}
