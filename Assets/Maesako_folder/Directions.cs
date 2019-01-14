using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directions : MonoBehaviour
{
    public GameObject Direct;
    public GameObject Direct_1;
    public GameObject Direct_2;
    public GameObject Door;
    public GameObject Enter;
    public GameObject T;
    public GameObject E;
    public GameObject E2;
    public Text tx;
    public int count;
    // Use this for initialization
    void Start ()
    {
        Direct = GameObject.Find("d_1");
        Direct.SetActive(false);
        Direct_1 = GameObject.Find("d_2");
        Direct_1.SetActive(false);
        Direct_2 = GameObject.Find("d_3");
        Direct_2.SetActive(false);
        Door = GameObject.Find("door_t");
        Door.SetActive(false);
        Enter = GameObject.Find("enter");
        Enter.SetActive(true);
        T = GameObject.Find("Tutorial");
        T.SetActive(true);
        E = GameObject.Find("E_1");
        E.SetActive(false);
        E2 = GameObject.Find("E_2");
        E2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("return"))
        {
            if (count == 0)
            {
                Direct.SetActive(true);
                Door.SetActive(true);
                T.SetActive(false);
                count = 1;
            }
            else if (count == 1)
            {
                Direct.SetActive(false);
                Direct_1.SetActive(true);
                count = 2;
            }
            else if (count == 2)
            {
                Direct_1.SetActive(false);
                Direct_2.SetActive(true);
                count = 3;
            }
            else if (count == 3)
            {
                Direct_2.SetActive(false);
                Door.SetActive(false);
                count = 4;
            }
            else if (count == 4)
            {
                tx.text = "";
                count = 103;
            }
            else if (count == 103)
            {
                tx.text = "";
                count = 5;
            }
            else if (count == 5)
            {
                E.SetActive(true);
                count = 6;
            }
            else if (count == 6)
            {
                E.SetActive(false);
                E2.SetActive(true);
                count = 7;
            }
            else if (count == 7)
            {
                Destroy(E2);
                count = 8;
            }
            
        }
	}
}
