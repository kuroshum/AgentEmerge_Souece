using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpbar : MonoBehaviour {

    public GameObject[] hp = new GameObject[6];

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Player_controller2.dam)
        {
            Destroy(hp[Player_controller2.HP-1]);
        }		
	}
}
