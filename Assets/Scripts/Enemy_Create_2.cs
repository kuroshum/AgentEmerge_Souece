using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Create_2 : MonoBehaviour
{

    public GameObject[] DOOR;
    public GameObject Enemy;
    public GameObject Player;
    public Vector3 rot;
    public Quaternion rotate;
    public Vector3 local;
    public int num;
    public int Pnum;
    public float timeLeft;
   
    /*--------------------------------敵の生成----------------------------------*/
    //ENEMY_CREATE E = new ENEMY_CREATE();

    public void Create_1()
    {
        num = Random.Range(0, DOOR.Length - 20);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_2()
    {
        num = Random.Range(3, DOOR.Length - 17);
        while (Pnum == num) num = Random.Range(3, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_3()
    {
        num = Random.Range(6, DOOR.Length - 11);
        while (Pnum == num) num = Random.Range(5, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_4()
    {
        num = Random.Range(9, DOOR.Length - 8);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_5()
    {
        num = Random.Range(12, DOOR.Length - 6);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_6()
    {
        num = Random.Range(14, DOOR.Length - 1);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_7()
    {
        num = Random.Range(17, DOOR.Length);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_8()
    {
        num = Random.Range(21, DOOR.Length);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }
    /*-------------------------------ここまで-----------------------------------*/

    // Use this for initialization
    void Start()
    {
        Bullet.cntEnemy = 0;
        Score.scoreRed = 0;
        Score2.Total = 0;
        for (int i = 0; i < 13; i++) {
            Enemy_Controller1.F[i] = 0;
        }
        //rotate = Quaternion.Euler(0, 180, 0);
        //local = GameObject.FindGameObjectWithTag("Start").transform.position;
        //local -= new Vector3(0f, 0f, 1.1f);
        //Instantiate(Player, local, rotate);
        
        Pnum = 100;
        //Create_1();
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        /*----------------------------敵の生成の間隔--------------------------------*/

        timeLeft -= Time.deltaTime;

        if (Player.transform.position.y > 33.3 && Enemy_Controller1.F[0] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_1();
                timeLeft = 3.0f;
            }
        }

        if (Player.transform.position.y > 28.3 && Enemy_Controller1.F[1] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_2();
                timeLeft = 3.0f;
            }
        }

        if (Player.transform.position.y > 23.3 && Enemy_Controller1.F[2] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_3();
                timeLeft = 3.0f;
            }
        }


        if (Player.transform.position.y > 18.3 && Enemy_Controller1.F[3] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_4();
                timeLeft = 3.0f;
            }
        }

        if (Player.transform.position.y > 13.3 && Enemy_Controller1.F[4] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_5();
                timeLeft = 3.0f;
            }
        }

        if (Player.transform.position.y > 8.3 && Enemy_Controller1.F[5] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_6();
                timeLeft = 3.0f;
            }
        }

        if (Player.transform.position.y > 3.3 && Enemy_Controller1.F[6] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_7();
                timeLeft = 3.0f;
            }
        }

        if (Player.transform.position.y > -2.3 && Enemy_Controller1.F[7] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_8();
                timeLeft = 3.0f;
            }
        }
        /*--------------------------------ここまで----------------------------------*/

    }


}
