using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour {

    Image img;

	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
        img.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
        if (Player_controller2.dam){
            this.img.color = new Color(0.5f, 0f, 0f, 0.5f);
            Player_controller2.dam = false;
        }else{
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
        }
	}
}
