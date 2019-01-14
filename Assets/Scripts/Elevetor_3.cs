using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevetor_3 : MonoBehaviour {


    private int frame;
    private float waitTime;
    private float currentTime;
    public bool stop;
    public bool down;
    public bool ctrl;
    public bool up;
    public bool rev;
    public bool up_l;
    public bool down_l;
    public bool ctrl_d;
    public bool ctrl_u;
    public float speed;
    public GameObject Evt;
    Vector3 pos;


    /*------------------------------------下に移動する---------------------------------------*/

    private void Down()
    {
        if (down)
        {
            Evt.transform.position -= new Vector3(0f, 2f * Time.deltaTime, 0f);
            rev = false;
        }
    }
    /*--------------------------------------ここまで-----------------------------------------*/


    /*----------------------------------エレベーターを止める---------------------------------*/
    private void Stop()
    {
        if (stop)
        {
            if (up == true)
            {
                up = false;
                up_l = true;
            }
            if (down == true)
            {
                down = false;
                down_l = true;
            }

            Evt.transform.position = pos;
            frame++;

            if (frame == 100 * (frame / 100))
            {
                stop = false;
                if (up_l == true)
                {
                    up = true;
                    up_l = false;
                }
                if (down_l == true)
                {
                    down = true;
                    down_l = false;
                }
            }
        }
    }

    /*--------------------------------------ここまで-----------------------------------------*/


    /*------------------------------------上に移動する---------------------------------------*/
    private void Up()
    {
        if (up)
        { 
            down = false;
            rev = false;
            Evt.transform.position -= new Vector3(0f, -2f * Time.deltaTime, 0f);
        }
    }

    /*--------------------------------------ここまで-----------------------------------------*/


    /*-------------------------------エレベータの上下の制御----------------------------------*/
    private void Ctrl()
    {
        if (ctrl)
        {
            if (Input.GetKey(KeyCode.UpArrow) && ctrl_d == false)
            {
                up = true;
                down = false;
                stop = false;
            }
            if (Input.GetKey(KeyCode.DownArrow) && ctrl_u == false)
            {
                down = true;
                up = false;
                stop = false;
            }
        }
    }

    /*--------------------------------------ここまで-----------------------------------------*/

    private void Ctrl_2()
    {
        if (ctrl && rev && stop && down_l) ctrl_d = true;
        else ctrl_d = false;

        if (ctrl && rev && stop && up_l) ctrl_u = true;
        else ctrl_u = false;
    }


    /*-------------------------衝突相手のtagがstageなら逆に動く------------------------------*/

    private void Reverse()
    {
        if (rev)
        {
            stop = true;
            if (down == true)
            {
                down = false;
                up = true;
            }
            else if (up == true)
            {
                up = false;
                down = true;
            }
        }
    }
    
    /*--------------------------------------ここまで-----------------------------------------*/

    // Use this for initialization
    void Start () {
        frame = 0;
        waitTime = 25.0f;
        currentTime = 0.0f;
        rev = false;
        stop = false;
        down = true;
        up = false;
        up_l = false;
        down_l = false;
        ctrl = false;
        ctrl_d = false;
        ctrl_u = false;
        speed = 100;
        
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        Down();
        Stop();
        Up();
        Ctrl();
        Ctrl_2();
    }

    /*---------------------------------エレベーターを逆向きに--------------------------------*/

    void OnCollisionEnter(Collision collision)
    {//衝突判定
        if (collision.gameObject.tag == "Stage")
        {
            rev = true;
            pos = Evt.transform.position;
            Reverse();
            //Debug.Log("stage");
        }
    }

    /*--------------------------------------ここまで-----------------------------------------*/

    /*------------------------------エレベーターの停止と制御---------------------------------*/

    void OnTriggerEnter(Collider collision)
    {//衝突判定
        if (collision.gameObject.tag == "floar")
        {
            //衝突相手のtagがfloarなら停止する
            stop = true;
            pos = Evt.transform.position;
            //Debug.Log("floar");
        }

        if (collision.gameObject.tag == "Player")
        {
            //Playerがエレベーターに入ったら制御できる
            ctrl = true;
           // Debug.Log("in");
        }
    }

    /*--------------------------------------ここまで-----------------------------------------*/


    /*-------------------------------エレベーターの制御外す----------------------------------*/
    void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //Playerがエレベーターから出たら制御外す
            ctrl = false;
            //Debug.Log("out");
        }
    }

    /*--------------------------------------ここまで-----------------------------------------*/

}
