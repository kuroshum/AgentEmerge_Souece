using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tuto: MonoBehaviour
{
    public Text window;
    public Text Script;
    public GameObject Finish;
    public GameObject gun;
    public int pushCount;
    public Animator anim;
    public Animator anim2;
    public Animator Eanim;
    public Animator Eanim2;
    public Animator Stop;
    public Animator Ca;
    public Animator Ca2;
    public GameObject Direct;
    public GameObject Direct_1;
    public GameObject Direct_2;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        anim2 = GetComponent<Animator>();
        anim2.SetBool("CM2", false);
        Eanim = GetComponent<Animator>();
        Eanim.SetBool("EA", false);
        Eanim2 = GetComponent<Animator>();
        Eanim2.SetBool("EA2", false);
        Stop = GetComponent<Animator>();
        Stop.SetBool("EA3", false);
        Ca = GetComponent<Animator>();
        Ca.SetBool("CM3", false);
        Ca2 = GetComponent<Animator>();
        Ca2.SetBool("CM4", false);
        Finish = GameObject.Find("finish");
        Finish.SetActive(false);
        gun = GameObject.Find("Gun_gun");
        gun.SetActive(false);
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("CM", false);
        if (Input.GetKeyDown("return"))
        {
            if (pushCount == 0)
            {
                window.text = "青い扉から敵がわきます";
                pushCount = 1;

            }
            else if (pushCount == 1)
            {
                window.text = "赤い扉は入ると文書が手に入ります\n（スコアアップ）";
                pushCount = 2;
            }
            else if (pushCount == 2)
            {
                window.text = "鉄の扉に入ると武器がアップグレードします";
                pushCount = 105;
            }
            else if (pushCount == 105)
            {
                gun.SetActive(true);
                window.text = "武器がアップグレードすると・・・？";
                pushCount = 3;
            }
            else if (pushCount == 3)
            {
                gun.SetActive(false);
                anim.SetBool("CM", true);
                window.text = "　";
                pushCount = 4;
            }
            else if (pushCount == 4)
            {
                Script.text = "       プレイヤーがエレベーターに入ると\n        上下矢印キーで操作できます";
                window.text = "";
                pushCount = 5;
            }
            else if (pushCount == 5)
            {
                window.text = "";
                Eanim.SetBool("EA", true);
                pushCount = 6;
            }
            else if (pushCount == 6)
            {
                window.text = "";
                Eanim2.SetBool("EA2", true);
                pushCount = 7;
            }
            else if (pushCount == 7)
            {
                Eanim.SetBool("EA", false);
                Stop.SetBool("EA3", true);
                anim2.SetBool("CM2", true);
                Script.text = "";
                window.text = "";
                pushCount = 8;
            }
            else if (pushCount == 8)
            {
                Script.text = "";
                window.text = "";
                pushCount = 9;
            }
            else if (pushCount == 9)
            {
                Script.text = "プレイヤーの操作";
                pushCount = 10;
            }
            else if (pushCount == 10)
            {
                StartCoroutine("Wait");
                Script.text = "移動：←　→　キー";
                pushCount = 11;
            }
            else if (pushCount == 11)
            {
                Script.text = "しゃがむ：↓キー";
                pushCount = 12;
            }
            else if (pushCount == 12)
            {
                Script.text = "銃を撃つ：Sキー";
                pushCount = 101;
            }
            else if (pushCount == 101)
            {
                Script.text = "しゃがみ撃ち：↓　＋　S　キー";
                pushCount = 13;
            }
            else if (pushCount == 13)
            {
                Script.text = "ローリング回避：Dキー\n転がっている間は無敵となり、敵の弾丸により攻撃を受けません";
                pushCount = 14;
            }
            else if (pushCount == 14)
            {
                Script.text = "カメラ操作";
                pushCount = 15;
            }
            else if (pushCount == 15)
            {
                Script.text = "ズームアウト：Mキー";
                Ca.SetBool("CM3", true);
                pushCount = 16;
            }
            else if (pushCount == 16)
            {
                Ca2.SetBool("CM4", true);
                Script.text = "ズームアップ：Nキー";
                pushCount = 100;
            }
            else if (pushCount == 100)
            {
                Finish.SetActive(true);
                Script.text = "";
                pushCount = 17;
            }
            else if (pushCount == 17)
            {
                SceneManager.LoadScene("Name");
               // pushCount = 18;
            }
            
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds( 3 );
        yield break;
    }
}
