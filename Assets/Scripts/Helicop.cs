using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < -15) Destroy(this.gameObject);
    }

}
