using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pname : MonoBehaviour {
    public static string playername;
    [SerializeField]
    private InputField inputField_;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnEndEdit(string text)
    {
        playername = text;
        SceneManager.LoadScene("Stage select");
    }
}
