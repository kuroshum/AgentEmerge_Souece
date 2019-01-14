using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase_hel : MonoBehaviour
{
    public Transform Target;
    public Vector3 set;

	// Use this for initialization
	void Start ()
    {
        set = GetComponent<Transform>().position - Target.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Transform>().position = Target.position + set;
	}
}
