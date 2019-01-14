using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoloowLight : MonoBehaviour
{

    GameObject Player;
    GameObject SpotLight;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        SpotLight.AddComponent<Light>();
    }
    // Update is called once per frame
    void Update()
    {

        SpotLight.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);

    }
}
