using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller1 : MonoBehaviour {
    private CharacterController Econ;
    private GameObject Player;
    public GameObject bullet;
    public GameObject SubBullet;
    public Transform muzzle;
    public Transform SQmuzzle;
    private Animator Eani;
    private RaycastHit Hit;
    private Ray Eray;
    private AudioSource Gun_sound;
    public bool des_1;
    public bool des_2;
    public bool des_3;
    public bool des_4;
    public bool player;
    public bool R;          //右左
    public bool S;
    public bool P;
    public bool atk;
    public bool squad;
    public bool death;
    public float Ptime;
    public float Gun_speed = 500;
    public float ETime;
    public float SubEtime;
    private float rotateSpeed = 2f;
    private float moveX;
    private float movement = 3f;
    private int distance;
    public static int Dmgcnt;
    public int num;
    public int Anum = 0;
    private int cnt = 0;
    private int Dcnt = 1;
    public static int[] F = new int[13] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };



    //〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇
    public static bool E;
    public static int e = 100;
    public static bool find;


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


    public int ENEMYNUM0;
    public int ENEMYNUM1;
    public int ENEMYNUM2;
    public int ENEMYNUM3;

    /*-----------------------------------------敵の攻撃--------------------------------------*/

    private void ATK(float Etime, float SubEtime,bool squad) {
        Eani.SetBool("run", false);
        player = false;
        cnt++;

        if (squad) {
            Vector3 Target = Player.transform.position;
            Target.y = transform.position.y;
            transform.LookAt(Target);
            Eani.SetBool("is_squad", true);
            Eani.SetBool("is_squad_gun", true);
            moveX = 0;
            Anum++;
        } else {
            Vector3 Target = Player.transform.position;
            Target.y = transform.position.y;
            transform.LookAt(Target);
            Eani.SetBool("is_gun", true);
            moveX = 0;
        }
    

        if (Mathf.Round(Etime) % 40 == 0) {
            GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
            Vector3 force;
            force = this.gameObject.transform.forward * Gun_speed;
            if (squad) bullets.transform.position = SQmuzzle.position;
            else bullets.transform.position = muzzle.position;
            bullets.GetComponent<Rigidbody>().AddForce(force);
            
            Gun_sound.PlayOneShot(Gun_sound.clip);
            atk = false;
            //〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇
//            if (E) E = false;
        }

    }

  /*  private void ATK_SUB(float Etime, float SubEtime) {
        Eani.SetBool("run", false);
        player = false;
        Vector3 Target = Player.transform.position;
        Target.y = transform.position.y;
        transform.LookAt(Target);
        Eani.SetBool("is_gun", true);
        Anum++;
        squad = false;
        moveX = 0;
                

        if (Mathf.Round(Etime) % 40 >= 0 && Mathf.Round(Etime) % 40 <= 5) {
            if (Mathf.Round(Ptime) % 10 == 0) {
                GameObject bullets = GameObject.Instantiate(SubBullet) as GameObject;
                Vector3 force;
                force = this.gameObject.transform.forward * Gun_speed;
                if (squad) bullets.transform.position = SQmuzzle.position;
                else bullets.transform.position = muzzle.position;
                bullets.GetComponent<Rigidbody>().AddForce(force);
               
                Gun_sound.PlayOneShot(Gun_sound.clip);
                atk = false;
//              if (E) E = false;
            }
            
        }
    }
    */
    /*-------------------------------------------ここまで---------------------------------------*/

    // Use this for initialization
    void Start() {
        Econ = GetComponent<CharacterController>();
        Eani = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        player = false;
        Eray = new Ray(transform.position, transform.forward);
        distance = 4;
        des_1 = false;
        des_2 = false;
        des_3 = false;
        des_4 = false;
        R = true;
        S = true;
        P = false;
        //L = false;
        suvivetime = 0f;
        Gun_sound = GetComponent<AudioSource>();
        //num = Random.Range(0, 5);

        //〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇
        E = false;
    }

    // Update is called once per frame
    void Update() {

        //Econ.height = Eani.GetFloat("ColliderHeight");
        //Econ.center = new Vector3(0, Eani.GetFloat("ColliderCenter"), 0);

        if (des_1 && des_2 && (des_3 || des_4)) Destroy(this.gameObject);

        if (death) {
            atk = false;
            Dcnt++;
        }
        if (Dcnt % 150 == 0) Destroy(this.gameObject);

        ETime += Time.deltaTime * 60;
        SubEtime = ETime;

        suvivetime += Time.deltaTime;

        if (roomout == false && roomsitu == false) {
            moveX = Time.deltaTime * movement;
            Ptime = Time.deltaTime;
            Vector3 direction;
            direction = new Vector3(moveX, 0, 0);
            float Etime = Time.deltaTime;
            float step = rotateSpeed * Time.deltaTime * 20;
            Quaternion myQ = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Lerp(transform.rotation, myQ, step);
            Eani.SetBool("run", true);

            Eray = new Ray(direction, transform.forward);
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.7f, transform.position.z), Eray.direction * distance, Color.red);
            if (atk) {
                int a = Random.Range(0, 2);
                if (a == 0 && cnt == 0) squad = true;
                if (a == 1 && cnt == 0) squad = false;
               
                ATK(ETime, SubEtime, squad);
                        
                 
            }
            else cnt = 0;
            if (!death) {
                if (R) {
                    if (transform.position.x - Player.transform.position.x > -7 && transform.position.x - Player.transform.position.x <= 1.5 &&  Mathf.Abs(Player.transform.position.z - transform.position.z) <= 0.5 && Mathf.Abs(Player.transform.position.y - transform.position.y) <= 2) {
                        atk = true;
                        find = true;
                    }
                    else if (suvivetime > 30f && Mathf.Abs(Player.transform.position.y - transform.position.y) <= 2) {
                        atk = true;
                        find = true;
                        suvivetime = 20f;
                    }
                    else {
                        player = true;
                        atk = false;

                        Eani.SetBool("run", true);
                        Eani.SetBool("is_gun", false);
                        Eani.SetBool("is_squad", false);
                        Eani.SetBool("is_squad_gun", false);
                        find = false;
                    }
                }
                else {
                    if (transform.position.x - Player.transform.position.x < 7 && transform.position.x - Player.transform.position.x >= 1.5 && transform.position.z - Player.transform.position.z <= 2 && Mathf.Abs(Player.transform.position.z - transform.position.z) <= 0.5 && Mathf.Abs(Player.transform.position.y - transform.position.y) <= 2) {
                        atk = true;
                        find = true;
                    }
                    else if (suvivetime > 30f && Mathf.Abs(Player.transform.position.y - transform.position.y) <= 2) {
                        atk = true;
                        find = true;
                        suvivetime = 20f;
                    }
                    else {
                        player = true;
                        Eani.SetBool("run", true);
                        Eani.SetBool("is_gun", false);
                        Eani.SetBool("is_squad", false);
                        Eani.SetBool("is_squad_gun", false);
                        find = false;
                    }
                }
            }

            //〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇〇
            if (E == true && Mathf.Abs(Player.transform.position.y - transform.position.y) <= 2) {
                ATK(ETime, SubEtime,squad);
            }
            if (Mathf.Abs(Player.transform.position.y - transform.position.y) > 1.5f) {
                E = false;
            }
        }

            //追加
            if (roomout) {
                Eani.SetBool("run", true);
                // Debug.Log("roomout");
                //            transform.position += new Vector3(0f, 0f, -1.5f * Time.deltaTime);
                if (transform.position.z < point) {
                    Eani.SetBool("run", false);
                    transform.rotation = Quaternion.Euler(transform.position.x - 26, 90, transform.position.z);
                    roomsitu = false;
                    roomout = false;
                }
            }
            //追加
            if (roomdes) {
                transform.rotation = Quaternion.Euler(transform.position.x - 26, 0, transform.position.z);
                Eani.SetBool("run", true);
                //            Eani.SetBool("run", false);

                //            transform.position += new Vector3(0f, 0f, +1.5f * Time.deltaTime);
                if (transform.position.z > dpoint) {
                    Eani.SetBool("run", false);
                    Destroy(this.gameObject);
                }
            }

            if (suvivetime >= 2f) {
                this.tag = "Enemy_stay";
            }

            if (suvivetime >= 30f) {
                this.tag = "Enemy_destroy";
                destroy = true;
//                roomsitu = true;
            }

        
    }

    void OnCollisionEnter(Collision co) {
        if (co.gameObject.tag == "Elevetor") des_3 = true;
        else des_3 = false;

        if (co.gameObject.tag == "OnElv") des_4 = true;
        else des_4 = false;

    }
    void OnTriggerEnter(Collider co) {
            if (co.gameObject.tag == "Return") {
//                destroy = false;
//                roomsitu = false;
                movement = -movement;
                R = !R;
                if (suvivetime > 30f)
                {
                    suvivetime = 25f;
                }
            }

            if (co.gameObject.tag == "Bullet") {
            //Destroy(this.gameObject);
            Destroy(muzzle);
            Destroy(SQmuzzle);
            Eani.SetBool("is_death", true);
            gameObject.layer = LayerMask.NameToLayer("Roll");
            death = true;
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
            if(co.gameObject.tag == "SubBullet") {
                Destroy(co.gameObject);
                Dmgcnt++;
                if(Dmgcnt % 3 == 0) {
                Destroy(muzzle);
                Destroy(SQmuzzle);
                Eani.SetBool("is_death", true);
                death = true;
                gameObject.layer = LayerMask.NameToLayer("Roll");
                //Destroy(this.gameObject);
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
            }
            if (co.gameObject.tag == "laser") {
            Destroy(muzzle);
            Destroy(SQmuzzle);
            Eani.SetBool("is_death", true);
            death = true;
            gameObject.layer = LayerMask.NameToLayer("Roll");
            //Destroy(this.gameObject);
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

        void OnTriggerExit(Collider co) {
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

        if (co.gameObject.tag == "Return") des_1 = false;
        if (co.gameObject.tag == "Death") des_2 = false;
    }

        void OnTriggerStay(Collider co) {
            if (co.gameObject.tag == "Door" && roomsitu == true && motion == false && destroy == false) {
                //Debug.Log("doorout");
                point = transform.position.z - 1.1f;
                roomout = true;
                motion = true;
                transform.rotation = Quaternion.Euler(transform.position.x - 26, 180, transform.position.z);
                //Debug.Log(point);
            }

            if (co.gameObject.tag == "Door" && destroy == true) {
                dpoint = transform.position.z + 1.1f;
                roomdes = true;
                Eani.SetBool("run", false);
            }

        if (co.gameObject.tag == "Return") des_1 = true;
        if (co.gameObject.tag == "Death") des_2 = true;

    }


}
