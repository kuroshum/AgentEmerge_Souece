using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour {
    public Vector3 local;
    public GameObject Player;
    public Vector3 rot;
    public Quaternion rotate;
    private AudioSource BGM;
    public bool heli;
    public bool b;
    private int cnt;

    // Use this for initialization
    void Start () {
        b = false;
        cnt = 0;
        local = GameObject.FindGameObjectWithTag("Start").transform.position;
        rotate = Quaternion.Euler(0, 180, 0);
        BGM = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (heli && cnt == 1) {
            Instantiate(Player, local, rotate);
            heli = false;
            BGM.PlayOneShot(BGM.clip);
            b = true;
        }
        if (!BGM.isPlaying && b) BGM.PlayOneShot(BGM.clip);

    }
    void OnTriggerEnter(Collider co) {
        if(co.gameObject.tag == "heli") {
            heli = true;
            cnt++;
        }
    }
}
