using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class Score2 : MonoBehaviour {
    public Text scoreTextE; //Text用変数
    public int scoreE;　//スコア計算用変数
    public Text scoreTextH; //Text用変数
    public int scoreH;　//スコア計算用変数
    public Text scoreTextR; //Text用変数
    public int scoreR;　//スコア計算用変数
    public Text scoreTextT; //Text用変数
    public int scoreT;　//スコア計算用変数
    public Text scoreTIME;
    public float stime;
    private int e = 0;
    private int h = 0;
    private int r = 0;
    private int t = 0;
    private int s = 0;
    private int EnemyS;
    private int HPS;
    private int RedDoor;
    public static int Total;
    public int Playtime;
    public bool E;
    public bool H;
    public bool R;

    void SetScore()
    {
        scoreTextE.text = string.Format("敵残滅数:{0}", scoreE);
        scoreTextH.text = string.Format("残機:{0}", scoreH);
        scoreTextR.text = string.Format("文書:{0}", scoreR);
        scoreTextT.text = string.Format("Total:{0}", scoreT);
        scoreTIME.text = string.Format("Time:{0}", Playtime);
    }

    void Start()
    {
        E = false;
        H = false;
        R = false;
        e = 0;
        h = 0;
        r = 0;
        t = 0;
        scoreTextE.text = "敵残滅数:0";//初期スコアを代入して表示
        scoreE = 0;
        scoreTextH.text = "残機:0";//初期スコアを代入して表示
        scoreH = 0;
        scoreTextR.text = "文書:0";//初期スコアを代入して表示
        scoreR = 0;
        scoreTextT.text = "Total:0";//初期スコアを代入して表示
        scoreT = 0;
        scoreTIME.text = "Time:0";
        stime = 0;
        EnemyS = Bullet.cntEnemy * 100;
        HPS = Player_controller2.HP * 100;
        RedDoor = Score.scoreRed;
        Total = EnemyS + HPS + RedDoor;
        Playtime = (int)Score.time;

        SaveScore(Pname.playername, Total);
    }

    void Update () {
       // if(s < Playtime) {
       //     stime++;
       //     s++;
       //     SetScore();
       // }
        if (e < EnemyS) {
            scoreE += 50;
            e += 50;
            SetScore();
        }
        else E = true;

        if (h < HPS) {
            scoreH += 10;
            h += 10;
            SetScore();
        }
        else H = true;

        if (r < RedDoor) {
            scoreR += 10;
            r += 10;
            SetScore();
        }
        else R = true;

        if (t < Total && E && H && R)
        {
            scoreT += 10;
            t += 10;
            SetScore();
        }

      /*  scoreE = 500 * Bullet.cntEnemy;
        scoreH = 100 * Player_controller2.HP;
        scoreR = Score.scoreRed;
        scoreT = scoreE + scoreH + scoreR;

        SetScore(); */
    }

    void SaveScore(string name, int Total) {
        string buff;
        StreamReader reader = new StreamReader("ScoreData" + Player_controller2.cene + ".txt", Encoding.UTF8);
        buff = reader.ReadToEnd();
        reader.Close();
        StreamWriter sw = new StreamWriter("ScoreData" + Player_controller2.cene + ".txt", false);
        sw.WriteLine(name + " " + Total);
        sw.Write(buff);
        sw.Flush();
        sw.Close();
    }
}
