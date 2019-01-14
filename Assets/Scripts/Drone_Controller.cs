using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Controller : MonoBehaviour
{
    private CharacterController Econ;
    private GameObject Player;
    public GameObject bullet;
    public GameObject Drone;
    public Transform muzzle;
    private Animator Eani;
    private RaycastHit Hit;
    private Ray Eray;
    private AudioSource Gun_sound;
    public bool player;
    public bool R;          //右左
    public bool S;
    public bool P;
    public bool Stop;
    public bool atk;
    public float Ptime;
    public float Gun_speed = 500;
    private float rotateSpeed = 2f;
    private float moveX;
    private float movement = 3f;
    private float DroneSpeed = 2.0f;
    private int distance;
    private int cnt;
    public static int[] F = new int[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };



    //〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇
    public static bool E;
    public static int e = 100;



    //追加
    private bool roomout = false;
    private bool roomsitu = true; //手前かドアの向こう側かの判定
    private bool motion = false; //動いてるか動いていないかの判定
    private bool destroy = false;
    private bool roomdes = false;
    private float suvivetime;
    //追加
    /* 手前側の場所(startpoint) */
    float point = 0.2f;
    float dpoint = 0.2f;


 /* public int ENEMYNUM0;
    public int ENEMYNUM1;
    public int ENEMYNUM2;
    public int ENEMYNUM3;

    /*-----------------------------------------敵の攻撃--------------------------------------*/

    private void ATK()
    {
        Eani.SetBool("run", false);
        //Debug.Log("human");
        player = false;

        Vector3 Target = Player.transform.position;
        Target.y = transform.position.y;
        transform.LookAt(Target);
        Eani.SetBool("is_gun", true);
        moveX = 0;
        cnt++;
        if (cnt % 40 == 0)
        {
            GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
            Vector3 force;
            force = this.gameObject.transform.forward * Gun_speed;
            bullets.GetComponent<Rigidbody>().AddForce(force);
            bullets.transform.position = muzzle.position;
            Gun_sound.PlayOneShot(Gun_sound.clip);
            atk = false;


            //〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇
            if (E)
            {
                E = false;
            }

        }

    }

    /*-------------------------------------------ここまで---------------------------------------*/

    // Use this for initialization
    void Start()
    {
        Econ = GetComponent<CharacterController>();
        Eani = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        player = false;
        Eray = new Ray(transform.position, transform.forward);
        distance = 4;
        R = true;
        S = true;
        P = false;
        cnt = 0;
        //L = false;
        suvivetime = 0f;
        Gun_sound = GetComponent<AudioSource>();

        //〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇
        E = false;
    }

    // Update is called once per frame
    void Update()
    {

        suvivetime += Time.deltaTime;

        if (Stop) DroneSpeed = 0.0f;
        else DroneSpeed = 2.0f;

        if (roomout == false && roomsitu == false)
        {
            moveX = Time.deltaTime * movement;
            Ptime = Time.deltaTime;
            Vector3 direction;
            direction = new Vector3(moveX, 0, 0);
            float Etime = Time.deltaTime;
            float step = rotateSpeed * Time.deltaTime * 20;
            Quaternion myQ = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Lerp(transform.rotation, myQ, step);
            //Eani.SetBool("run", true);
            transform.Translate(direction * DroneSpeed); 

            Eray = new Ray(direction, transform.forward);
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.7f, transform.position.z), Eray.direction * distance, Color.red);

            if (atk) ATK();

            if (R)
            {
                if (transform.position.x - Player.transform.position.x > -7 && transform.position.x - Player.transform.position.x <= 1.5 && Mathf.Abs(Player.transform.position.y - transform.position.y) <= 2)
                {
                    atk = true;
                    Stop = true;
                }
                else
                {
                    player = true;
                    atk = false;
                    Stop = false;
                    //Eani.SetBool("run", true);
                    //Eani.SetBool("is_gun", false);
                }
            }
            else
            {
                if (transform.position.x - Player.transform.position.x < 7 && transform.position.x - Player.transform.position.x >= 1.5 && Mathf.Abs(Player.transform.position.y - transform.position.y) <= 2)
                {
                    atk = true;
                    Stop = true;
                }
                else
                {
                    player = true;
                    Stop = false;
                    Eani.SetBool("run", true);
                    Eani.SetBool("is_gun", false);
                }
            }


            //〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇
            if (E == true && Mathf.Abs(Player.transform.position.y - transform.position.y) <= 2)
            {
                ATK();
            }
        }

        //追加
        if (roomout)
        {
            //Eani.SetBool("run", true);
           // transform.Translate(direction * DroneSpeed);
            // Debug.Log("roomout");
            //            transform.position += new Vector3(0f, 0f, -1.5f * Time.deltaTime);
            if (transform.position.z < point)
            {
                Eani.SetBool("run", false);
                transform.rotation = Quaternion.Euler(transform.position.x - 26, 90, transform.position.z);
                roomsitu = false;
                roomout = false;
            }
        }
        //追加
        if (roomdes)
        {
            transform.rotation = Quaternion.Euler(transform.position.x - 26, 0, transform.position.z);
            Eani.SetBool("run", true);
            //            Eani.SetBool("run", false);

            //            transform.position += new Vector3(0f, 0f, +1.5f * Time.deltaTime);
            if (transform.position.z > dpoint)
            {
                Eani.SetBool("run", false);
                Destroy(this.gameObject);
            }
        }

        if (suvivetime >= 2f)
        {
            this.tag = "Enemy_stay";
        }

        if (suvivetime >= 30f)
        {
            this.tag = "Enemy_destroy";
            destroy = true;
            roomsitu = true;
        }

    }

    void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag == "Return")
        {
            movement = -movement;
            R = !R;
        }

        if (co.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(co.gameObject);
            if (co.gameObject.tag == "FLOAR1") F[0]--;
            if (co.gameObject.tag == "FLOAR2") F[1]--;
            if (co.gameObject.tag == "FLOAR3") F[2]--;
            if (co.gameObject.tag == "FLOAR4") F[3]--;
            if (co.gameObject.tag == "FLOAR5") F[4]--;
            if (co.gameObject.tag == "FLOAR6") F[5]--;
            if (co.gameObject.tag == "FLOAR7") F[6]--;
            if (co.gameObject.tag == "FLOAR8") F[7]--;
            if (co.gameObject.tag == "FLOAR9") F[8]--;
            if (co.gameObject.tag == "FLOAR10") F[9]--;
            if (co.gameObject.tag == "FLOAR11") F[10]--;
            if (co.gameObject.tag == "FLOAR12") F[11]--;
            if (co.gameObject.tag == "FLOAR13") F[12]--;


        }

        if (co.gameObject.tag == "FLOAR1") F[0]++;
        if (co.gameObject.tag == "FLOAR2") F[1]++;
        if (co.gameObject.tag == "FLOAR3") F[2]++;
        if (co.gameObject.tag == "FLOAR4") F[3]++;
        if (co.gameObject.tag == "FLOAR5") F[4]++;
        if (co.gameObject.tag == "FLOAR6") F[5]++;
        if (co.gameObject.tag == "FLOAR7") F[6]++;
        if (co.gameObject.tag == "FLOAR8") F[7]++;
        if (co.gameObject.tag == "FLOAR9") F[8]++;
        if (co.gameObject.tag == "FLOAR10") F[9]++;
        if (co.gameObject.tag == "FLOAR11") F[10]++;
        if (co.gameObject.tag == "FLOAR12") F[11]++;
        if (co.gameObject.tag == "FLOAR13") F[12]++;
    }

    void OnTriggerExit(Collider co)
    {
        if (co.gameObject.tag == "FLOAR1") F[0]--;
        if (co.gameObject.tag == "FLOAR2") F[1]--;
        if (co.gameObject.tag == "FLOAR3") F[2]--;
        if (co.gameObject.tag == "FLOAR4") F[3]--;
        if (co.gameObject.tag == "FLOAR5") F[4]--;
        if (co.gameObject.tag == "FLOAR6") F[5]--;
        if (co.gameObject.tag == "FLOAR7") F[6]--;
        if (co.gameObject.tag == "FLOAR8") F[7]--;
        if (co.gameObject.tag == "FLOAR8") F[7]--;
        if (co.gameObject.tag == "FLOAR9") F[8]--;
        if (co.gameObject.tag == "FLOAR10") F[9]--;
        if (co.gameObject.tag == "FLOAR11") F[10]--;
        if (co.gameObject.tag == "FLOAR12") F[11]--;
        if (co.gameObject.tag == "FLOAR13") F[12]--;
    }

    void OnTriggerStay(Collider co)
    {
        if (co.gameObject.tag == "Door" && roomsitu == true && motion == false)
        {
            //Debug.Log("doorout");
            point = transform.position.z - 1.1f;
            roomout = true;
            motion = true;
            transform.rotation = Quaternion.Euler(transform.position.x - 26, 180, transform.position.z);
            //Debug.Log(point);
        }

        if (co.gameObject.tag == "Door" && destroy == true)
        {
            dpoint = transform.position.z + 1.1f;
            roomdes = true;
            Eani.SetBool("run", false);
        }
    }


}
