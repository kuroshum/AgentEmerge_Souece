using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bikkuri : MonoBehaviour {

    public GameObject ikkuri;

    // Use this for initialization
    void Start () {
        ikkuri.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Enemy_Controller1.find)
        {
            if (Enemy_Controller1.E)
            {
                ikkuri.SetActive(true);
            }
            if (!Enemy_Controller1.E)
            {
                ikkuri.SetActive(true);
            }

        }
        if (!Enemy_Controller1.find)
        {
            if (Enemy_Controller1.E)
            {
                ikkuri.SetActive(true);
            }
            if (!Enemy_Controller1.E)
            {
                ikkuri.SetActive(false);
            }
        }
    }
}
