using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText; //Text用変数
    public static int score;　//スコア計算用変数
    public Text TIME;
    public static float time;
    //public GameObject NUMRED;
    public Text numRed;
    public static float num;
    public GameObject help;
    //public GameObject all;
    private AudioSource DoorIn;
    public static int scoreRed = 0;
    public int cnt = 0;
    public int cnt2 = 0;
    public int cnt3 = 0;
    public int cnt4 = 0;
    public int allcnt;
    public int sint = 0; 
    public bool bhelp;
    public int helpcnt;

    void SetScore()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        DoorIn = audioSource;
        scoreText.text = string.Format("Score:{0}", score);
        TIME.text = string.Format("Time:{0}", time.ToString("F2"));
        numRed.text = string.Format("機密文書数:{0}", num);
    }

    void Start()
    {
        scoreText.text = "Score:0";//初期スコアを代入して表示
        score = 0;
        TIME.text = "Time:0";
        time = 0;
        numRed.text = "機密文書数:{0}";
        num = 0;
        allcnt = 0;
        helpcnt = 1;
        help.SetActive(false);
        //all.SetActive(false);
        bhelp = false;
    }

    void Update()
    {
        if (sint == 0) {
            score = 0;
            num = 0;
            allcnt = 0;
            sint++;
        }
        //if (allcnt >= 4) all.SetActive(true);
        if (bhelp) helpcnt++;
        time += Time.deltaTime;
        if (Bullet.SCORE_B)
        {
            score += 100;
            Bullet.SCORE_B = false;
        }
        if (helpcnt % 50 == 0) {
            help.SetActive(false);
            bhelp = false;
            helpcnt = 0;
        }
        if (Player_controller2.SCOREP) {
            if(cnt == 0) {
                score += 500;
                scoreRed += 500;
                num++;
                Player_controller2.SCOREP = false;
                cnt++;
                allcnt++;
                DoorIn.PlayOneShot(DoorIn.clip);
                help.SetActive(true);
                bhelp = true;
            }

        }
        if(Player_controller2.SCOREP2) {
            if (cnt2 == 0) {
                score += 500;
                scoreRed += 500;
                num++;
                Player_controller2.SCOREP2 = false;
                cnt2++;
                allcnt++;
                DoorIn.PlayOneShot(DoorIn.clip);
                help.SetActive(true);
                bhelp = true;
            }
        }

        if (Player_controller2.SCOREP3) {
            if (cnt3 == 0) {
                score += 500;
                scoreRed += 500;
                num++;
                Player_controller2.SCOREP3 = false;
                cnt3++;
                allcnt++;
                DoorIn.PlayOneShot(DoorIn.clip);
                help.SetActive(true);
                bhelp = true;
            }
        }

        if (Player_controller2.SCOREP4) {
            if (cnt4 == 0) {
                score += 500;
                scoreRed += 500;
                num++;
                Player_controller2.SCOREP4 = false;
                cnt4++;
                allcnt++;
                DoorIn.PlayOneShot(DoorIn.clip);
                help.SetActive(true);
                bhelp = true;
            }
        }
        SetScore();
    }
}
