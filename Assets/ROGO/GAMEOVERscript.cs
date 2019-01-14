using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GAMEOVERscript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void Button(int n)
    {
        switch (n)
        {
            case 0://りとらい

                if (name == "Button") MenuS.StageNamber++;          // aはステージ番号 宣言はけしたりうまくしといてください
                SceneManager.LoadScene("Stage"+ MenuS.StageNamber); //ステージ選択時にpublic static int でステージ番号をください
                break;
            case 1://タイトル

                SceneManager.LoadScene("title"); 
                break;
            case 2://ステージ選択画面

                SceneManager.LoadScene("stage select"); //ステージ選択画面にしといてください
                break;
        }



    }

   
}
