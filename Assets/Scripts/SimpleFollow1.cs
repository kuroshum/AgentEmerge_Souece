using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow1 : MonoBehaviour {

    GameObject Player;
    GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera");
        mainCamera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);

    }
}
