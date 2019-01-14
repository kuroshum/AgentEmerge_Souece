using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuS : MonoBehaviour
{
    public static int StageNamber;
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);

    }
    public void SelectStage(int n)
    {
        if (n == 0) {
            SceneManager.LoadScene("title"); 
            }
        else if (n < 5) { StageNamber=n; SceneManager.LoadScene("stage" + n); }
    }
}

