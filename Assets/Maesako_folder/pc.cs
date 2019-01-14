using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pc : MonoBehaviour
{
    public GameObject P;
    private Vector3 pl = new Vector3(0f,0f,0f);

	// Use this for initialization
	void Start ()
    {
        pl += transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Return")
        {
            this.transform.Translate(pl);
        }
    }
}
