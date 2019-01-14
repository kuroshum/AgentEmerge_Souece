using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpbar2 : MonoBehaviour {

    public GameObject[] hp = new GameObject[5];
    public int point;

    // Use this for initialization
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {
        
        
            point = Player_controller2.HP;
            Destroy(hp[point]);
        
    }
}
