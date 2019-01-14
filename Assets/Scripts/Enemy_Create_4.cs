using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Create_4 : MonoBehaviour
{

    public GameObject[] DOOR;
    public GameObject Enemy;
    public int num;
    public int Pnum;
    public float timeLeft;
    public Vector3 rot;
    public Quaternion rotate;

    /*--------------------------------敵の生成----------------------------------*/
    //ENEMY_CREATE E = new ENEMY_CREATE();

    public void Create_1()
    {
        num = Random.Range(0, DOOR.Length);
        while (Pnum == num) num = Random.Range(0, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_2()
    {
        num = Random.Range(3, DOOR.Length);
        while (Pnum == num) num = Random.Range(3, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    public void Create_3()
    {
        num = Random.Range(5, DOOR.Length);
        while (Pnum == num) num = Random.Range(5, DOOR.Length);
        Instantiate(Enemy, DOOR[num].transform.position, rotate);
        Pnum = num;
    }

    /*-------------------------------ここまで-----------------------------------*/

    // Use this for initialization
    void Start()
    {
        rotate = Quaternion.Euler(0, 180, 0);
        Pnum = 100;
        Create_1();
    }

    // Update is called once per frame
    void Update()
    {

        /*----------------------------敵の生成の間隔--------------------------------*/

        timeLeft -= Time.deltaTime;

        if (transform.position.y > -1)
        {
            if (timeLeft <= 0.0)
            {
                Create_1();
                timeLeft = 5.0f;
            }
        }

        if (transform.position.y > -8)
        {
            if (timeLeft <= 0.0)
            {
                Create_2();
                timeLeft = 5.0f;
            }
        }

        if (transform.position.y > -13)
        {
            if (timeLeft <= 0.0)
            {
                Create_3();
                timeLeft = 5.0f;
            }
        }
        /*--------------------------------ここまで----------------------------------*/
    }


}
