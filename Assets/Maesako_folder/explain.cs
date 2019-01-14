using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explain : MonoBehaviour
{
    public int count;
    public GameObject Ex;

	// Use this for initialization
	void Start ()
    {
        Ex.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            Ex.SetActive(true);
            StartCoroutine("Menu");
        }
	}

    IEnumerator Menu()
    {
       yield return new WaitForSeconds(1.0f);
        while (!Input.GetKeyDown("space"))
        {
            yield return 0;
        }
        Ex.SetActive(false);
       // yield break;
    }
}
