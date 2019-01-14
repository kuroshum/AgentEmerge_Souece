using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWepon : MonoBehaviour {

    public GameObject[] Wepon;
    public static int Num;
    public static int PreNum;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < Wepon.Length; i++) {
            if(Wepon[i] != null) Wepon[i].SetActive(false);
        }
        Num = 0;
        Wepon[Num].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		switch(Num) {
            case 1:
                Wepon[PreNum].SetActive(false);
                Wepon[Num].SetActive(true);
                break;
            case 2:
                Wepon[PreNum].SetActive(false);
                Wepon[Num].SetActive(true);
                break;
            case 3:
                Wepon[PreNum].SetActive(false);
                Wepon[Num].SetActive(true);
                break;
        }
	}
}
