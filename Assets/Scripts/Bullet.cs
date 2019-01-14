using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    //public GameObject player;
    public static bool SCORE_B = false;
    public static int cntEnemy = 0;
    // public Text scoreText; //Text用変数
    //public int score;　//スコア計算用変数

   
    void OnTriggerEnter(Collider collision)
    {//衝突判定
        if (collision.gameObject.tag == "Enemy_stay")
        {
            //衝突相手のtagがbulletまたEnemyなら自分と衝突相手を消す
           // Destroy(this.gameObject);
            //〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇
            Enemy_Controller1.E = true;
        }
        if (collision.gameObject.tag == "Player")
        {
            //衝突相手のtagがbulletまたEnemyなら自分と衝突相手を消す
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Stage" )
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy_stay" || collision.gameObject.tag == "Enemy_destroy")
        {
            if (Enemy_Controller1.Dmgcnt % 3 == 0) {
                SCORE_B = true;
                cntEnemy++;
            }
        }
        else
        {
            SCORE_B = false;
        }
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage") Destroy(this.gameObject);
    }
}
