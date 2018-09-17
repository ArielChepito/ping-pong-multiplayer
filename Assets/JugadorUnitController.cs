using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JugadorUnitController : NetworkBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!hasAuthority)
        {
            return;
        }
        float speed = .2f;


        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(gameObject);
        }

        if (gameObject.tag == "Jugador1")
            transform.Translate(0, Input.GetAxis("Horizontal") * speed, 0);
        else
            transform.Translate(0, Input.GetAxis("Vertical") * speed, 0);

    }
}
