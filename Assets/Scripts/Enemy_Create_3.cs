using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Create_3 : MonoBehaviour
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
        num = Random.Range(0, DOOR.Length - 24);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_2()
    {
        num = Random.Range(1, DOOR.Length -21);
        while (Pnum == num) num = Random.Range(3, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_3()
    {
        num = Random.Range(2, DOOR.Length -18);
        while (Pnum == num) num = Random.Range(5, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_4()
    {
        num = Random.Range(6, DOOR.Length -15);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_5()
    {
        num = Random.Range(7, DOOR.Length -12);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_6()
    {
        num = Random.Range(11, DOOR.Length -9);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_7()
    {
        num = Random.Range(15, DOOR.Length -6);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_8()
    {
        num = Random.Range(18, DOOR.Length -3);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_9()
    {
        num = Random.Range(20, DOOR.Length);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_10()
    {
        num = Random.Range(21, DOOR.Length);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_11()
    {
        num = Random.Range(23, DOOR.Length);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_12()
    {
        num = Random.Range(25, DOOR.Length);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_13()
    {
        num = Random.Range(27, DOOR.Length);
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
        rotate = Quaternion.Euler(0, 180, 0);
        local = GameObject.FindGameObjectWithTag("Start").transform.position;
        //local = DOOR[0].transform.position;
        //local -= new Vector3(0f,0f,1.1f);
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

        if (Player.transform.position.x < 33 && Player.transform.position.y > 32.7 && Enemy_Controller1.F[0] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_1();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.x < 33 && Player.transform.position.y > 28.7 && Enemy_Controller1.F[1] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_2();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 24.7 && Player.transform.position.x < 33 && Enemy_Controller1.F[2] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_3();
                timeLeft = 5.0f;
            }
        }


        if (Player.transform.position.y > 20.7 && Player.transform.position.x < 33 && Enemy_Controller1.F[3] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_4();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 16.7 && Player.transform.position.x < 33 && Enemy_Controller1.F[4] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_5();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 12.7 && Player.transform.position.x < 33 && Enemy_Controller1.F[5] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_6();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 12.7 && Enemy_Controller1.F[6] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_7();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 16.7 && Enemy_Controller1.F[7] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_8();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 20.7 && Enemy_Controller1.F[8] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_9();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 24.7 && Enemy_Controller1.F[9] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_10();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 28.7 && Enemy_Controller1.F[10] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_11();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 32.7 && Enemy_Controller1.F[11] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_12();
                timeLeft = 5.0f;
            }
        }

        if (Player.transform.position.y > 36.7 && Enemy_Controller1.F[12] < 2)
        {
            if (timeLeft <= 0.0)
            {
                Create_13();
                timeLeft = 5.0f;
            }
        }
        /*--------------------------------ここまで----------------------------------*/

    }


}
