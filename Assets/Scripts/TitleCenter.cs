using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCenter : MonoBehaviour {

    void Start()
    {
        transform.position = new Vector3(Camera.main.transform.position.x - 150, Camera.main.transform.position.y + 10, 0);
    }
}
