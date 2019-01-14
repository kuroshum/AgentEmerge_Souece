using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Create_1 : MonoBehaviour {

    public GameObject[] DOOR;
    public GameObject Enemy;
    public GameObject Drone;
    public GameObject Player;
    public Vector3 rot;
    public Quaternion rotate;
    public Vector3 local;
   
    public int num;
    public int Pnum;
    public int ENEMYNUM0;
    public int ENEMYNUM1;
    public int ENEMYNUM2;
    public int ENEMYNUM3;
    private float timeLeft;
    

    /*--------------------------------敵の生成----------------------------------*/

    //ENEMY_CREATE E = new ENEMY_CREATE();

    public void Create_1()
    {
        num = Random.Range(0, DOOR.Length - 4);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
        Debug.Log("1");
    }

    public void Create_2()
    {
        num = Random.Range(2, DOOR.Length - 2);
        while (Pnum == num) num = Random.Range(3, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
        Debug.Log("2");
    }

    public void Create_3()
    {
        num = Random.Range(3, DOOR.Length - 1);
        while (Pnum == num) num = Random.Range(5, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Debug.Log("3");
    }

    public void Create_4()
    {
        num = Random.Range(5, DOOR.Length);
        while (Pnum == num) num = Random.Range(5, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
        Debug.Log("4");
    }

    /*-------------------------------ここまで-----------------------------------*/

    // Use this for initialization
    void Start () {
        Bullet.cntEnemy = 0;
        Score.scoreRed = 0;
        Score2.Total = 0;
        for(int i = 0; i < 13; i++) {
            Enemy_Controller1.F[i] = 0;
        }
        rotate = Quaternion.Euler(0, 180, 0);
        local = GameObject.FindGameObjectWithTag("Start").transform.position;
    
        //local = DOOR[0].transform.position;
        //local -= new Vector3(0f,0f,1.1f);
        // Instantiate(Player, local, rotate);

        Pnum = 100;
        //Create_1();
    }
	    
	// Update is called once per frame
	void Update () {
        Player = GameObject.FindWithTag("Player");
        /* ENEMYNUM0 = Enemy_Controller1.F[0];
           ENEMYNUM1 = Enemy_Controller1.F[1];
           ENEMYNUM2 = Enemy_Controller1.F[2];
           ENEMYNUM3 = Enemy_Controller1.F[3];

           /*----------------------------敵の生成の間隔--------------------------------*/

        timeLeft -= Time.deltaTime;

         if (Player.transform.position.y > 31.7 && Enemy_Controller1.F[0] < 2)
         {
              if (timeLeft <= 0.0)
              {
                  Create_1();
                  timeLeft = 5.0f;
              }
         }

         if(Player.transform.position.y > 27.7 && Enemy_Controller1.F[1] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_2();
                timeLeft = 5.0f;
            }
        }

         if (Player.transform.position.y > 23.7 && Enemy_Controller1.F[2] < 2)
         {
             if (timeLeft <= 0.0)
             {
                 Create_3();
                 timeLeft = 5.0f;
             }
         }
      

        if (Player.transform.position.y > 18.7 && Enemy_Controller1.F[3] < 2)
        {
            if (timeLeft <= 0.0)
            {
                 Create_4();
                timeLeft = 5.0f;
            }
        }
        /*--------------------------------ここまで----------------------------------*/

    }

}
