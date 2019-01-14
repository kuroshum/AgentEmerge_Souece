using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player_controller2 : MonoBehaviour
{
    public static int cene = 0;
//    public int cenenum;
    CharacterController cCon;
    //Renderer renderer;
    private Animator animator;
    public GameObject bullet;
    public GameObject SubBullet;
    public GameObject Laser;
    public Transform muzzle;
    public Transform SQmuzzle;
    private AudioSource Gun_Sound1;
    private AudioSource Gun_Sound2;
    private AudioSource DoorIn;
    private Rigidbody rigid;
    private float rotateSpeed;
    private float movement;
    private float inv_Time;
    private float moveX;
    private float moveZ;
    public float Speed;
    public float Gun_speed;
    private bool roomsitu;
    private bool roomout;
    private bool motion;
    private bool roomin;
    public static bool dam;
    public static bool exit;
    public static bool SCOREP;
    public static bool SCOREP2;
    public static bool SCOREP3;
    public static bool SCOREP4;
    private bool goal;
    private int wepon;
    public bool squad;
    public bool gun;
    public bool wait;
    public bool des_1;
    public bool des_2;
    public bool des_3;
    public bool des_4;
    public bool roll;
    public static bool damage = false;
    private int cnt;
    private int Dmgcnt = 0;
    private int Dmgcnt2 = 0;
    private int Wcnt;
    private int Rcnt;
    public int hp;
    //変更static
    public static int HP = 5;
    public float Ptime;
    public float SubPtime;
    public int stagenum;

    //Enemy_Controller Enemy = new Enemy_Controller();
    Bullet B = new Bullet();

    void Start()
    {
        animator = GetComponent<Animator>();
        cCon = GetComponent<CharacterController>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        Gun_Sound1 = audioSources[0];
        Gun_Sound2 = audioSources[1];
        rigid = GetComponent<Rigidbody>();
        //renderer = GetComponent<Renderer>();
        roomsitu = false;
        roomout = false;
        motion = false;
        des_1 = false;
        des_2 = false;
        des_3 = false;
        des_4 = false;
        gun = false;
        wait = false;
        exit = false;
        SCOREP = false;
        SCOREP2 = false;
        SCOREP3 = false;
        SCOREP4 = false;
        movement = 3f;
        rotateSpeed = 2f;
        moveX = 0f;
        moveZ = 0f;
        cnt = 0;
        Wcnt = 0;
        wepon = 0;
        inv_Time = 300f;
        Dmgcnt = 0;
        Dmgcnt2 = 0;
        HP = 5;
        Rcnt = 1;
        animator.SetBool("is_fall", true);

        cene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        stagenum = StageScore.k;

        if (SceneManager.GetActiveScene().name == "Stage1") {
            cene = 1;
        }
        else if (SceneManager.GetActiveScene().name == "stage2") {
            cene = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Stage3") {
            cene = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Stage4") {
            cene = 4;
        }
        else {
            cene = 1;
        }
//        cenenum = cene;

        hp = HP;
        /*---------------------------移動の制御--------------------------------------*/
        moveX = Input.GetAxis("Horizontal") * Time.deltaTime * movement;
        Ptime += Time.deltaTime * 60;
        SubPtime = Ptime;
        Vector3 direction = new Vector3(moveX, 0, 0);

        if (roll) Rcnt++;
        if(Rcnt % 50 == 0) {
            gameObject.layer = LayerMask.NameToLayer("Player");
            roll = false;
            Rcnt = 1;
        }

        if (direction.magnitude > 0.01f){
            float step = rotateSpeed * Time.deltaTime * 20;
            Quaternion myQ = Quaternion.LookRotation(direction);
            this.transform.rotation = Quaternion.Lerp(transform.rotation, myQ, step);
            animator.SetBool("run", true);
        }else
            animator.SetBool("run", false);

        if (Input.GetKeyDown(KeyCode.D)) {
            animator.SetBool("is_roll", true);
            gameObject.layer = LayerMask.NameToLayer("Roll");
            roll = true;
        }
        else animator.SetBool("is_roll", false);


        if (Input.GetKey(KeyCode.DownArrow)) {
            animator.SetBool("is_squad", true);
            moveX = 0;
            //muzzle.position = new Vector3(muzzle.position.x, muzzle.position.y - 1, muzzle.position.z);
            if (Input.GetKey(KeyCode.S)) {
                animator.SetBool("is_squad_gun", true);
                moveX = 0;
                squad = true;
                //muzzle.position = SQmuzzle.position;
            }
            else {
                animator.SetBool("is_squad_gun", false);
                squad = false;
            }
        }
        else {
            animator.SetBool("is_squad", false);
            animator.SetBool("is_squad_gun", false);
            squad = false;
        }/*---------------------------------ここまで------------------------------------*/

        /*---------------------------------銃の制御-------------------------------------*/
        //if (Input.GetKey(KeyCode.Q)) gun = true;
        //else gun = false;


        if (Input.GetKey(KeyCode.S)) {
            animator.SetBool("is_gun", true);
            moveX = 0;
            switch (wepon) {
                case 0:
                    if (Mathf.Round(Ptime) % 40 == 0) {
                        GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
                        Vector3 force;
                        force = this.gameObject.transform.forward * Gun_speed;
                        bullets.GetComponent<Rigidbody>().AddForce(force);
                        if(squad) bullets.transform.position = SQmuzzle.position;
                        else bullets.transform.position = muzzle.position;
                        Gun_Sound1.PlayOneShot(Gun_Sound1.clip);
                    }
                    break;
                case 1:
                    if (Mathf.Round(Ptime) % 40 >= 0 && Mathf.Round(Ptime) % 40 <= 20) {
                        if (Mathf.Round(Ptime) % 3 == 0) {
                            GameObject bullets = GameObject.Instantiate(SubBullet) as GameObject;
                            Vector3 force;
                            force = this.gameObject.transform.forward * Gun_speed;
                            bullets.GetComponent<Rigidbody>().AddForce(force);
                            if (squad) bullets.transform.position = SQmuzzle.position;
                            else bullets.transform.position = muzzle.position;
                            Gun_Sound1.PlayOneShot(Gun_Sound1.clip);
                            Wcnt++;
                            if (Wcnt % 40 == 0) W1Cor();
                        }
                    }
                    break;
                case 2:
                    if (Mathf.Round(Ptime) % 60 == 0) {
                        GameObject bullets = GameObject.Instantiate(Laser) as GameObject;
                        Vector3 force;
                        force = this.gameObject.transform.forward * Gun_speed * 2;
                        bullets.GetComponent<Rigidbody>().AddForce(force);
                        if (squad) bullets.transform.position = SQmuzzle.position;
                        else bullets.transform.position = muzzle.position;
                        Gun_Sound2.PlayOneShot(Gun_Sound2.clip);
                    }
                    break;

            }
        }
        else animator.SetBool("is_gun", false);

        
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Locomotion.Jump")) animator.SetBool("is_gun", false);
        
        /*------------------------------------ここまで-------------------------------------*/

        /*---------------------------------ドアの出入り------------------------------------*/
        if (roomin)
        {
            moveX = 0;
            animator.SetBool("run", true);
            transform.position += new Vector3(0f, 0f, 1.5f * Time.deltaTime);
            if (transform.position.z >= endpoint)
            {
                animator.SetBool("run", false);
                roomin = false;
                roomsitu = true;
                motion = false;
                if(goal && cene < 3) SceneManager.LoadScene("gameClear");
                if(goal && cene == 3 ) SceneManager.LoadScene("LastgameClear");
            }
        }

        if (roomout)
        {
            moveX = 0;
            animator.SetBool("run", true);
            transform.position += new Vector3(0f, 0f, -1.5f * Time.deltaTime);
            if (transform.position.z <= startpoint)
            {
                animator.SetBool("run", false);
                roomout = false;
                roomsitu = false;
                motion = false;
            }
        }


        /*-----------------------------------ここまで------------------------------------------*/


        /*-----------------------------エレベータに潰される------------------------------------*/

        if (des_1 && des_2 && (des_3 || des_4)) SceneManager.LoadScene("Gameover");

        /*-----------------------------------ここまで------------------------------------------*/

        if (HP <= 0) SceneManager.LoadScene("Gameover");

        cCon.height = animator.GetFloat("ColliderHeight");
        cCon.center = new Vector3(0,animator.GetFloat("ColliderCenter"),0);
       // cCon.radius = animator.GetFloat("ColliderRadius");
        
 
    }

    private void FixedUpdate()
    {
        Vector3 vector = new Vector3(moveX * Speed, 0, 0);
        cCon.Move(vector);
    }

    /* ドアの向こう側の場所(endpoint)と手前側の場所(startpoint) */
    float endpoint = 0f;
    float startpoint = 0f;

    IEnumerator W1Cor() {
        yield return new WaitForSeconds(2.0f);
    }


   
    void OnTriggerStay(Collider co)
    {
        /*---------------------------------------ドアの出入りのための制御------------------------------------------*/

        if (co.gameObject.tag == "Red" && Input.GetKeyDown(KeyCode.A) && roomsitu == false && motion == false)
        {
            Debug.Log("doorin");
            endpoint = transform.position.z + 1.1f;
            roomin = true;
            motion = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        if (co.gameObject.tag == "Red" && Input.GetKeyDown(KeyCode.A) && roomsitu == true && motion == false)
        {
            Debug.Log("doorout");
            startpoint = transform.position.z - 1.1f;
            roomout = true;
            motion = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if(co.gameObject.tag == "Exit" && Input.GetKeyDown(KeyCode.A) && roomsitu == false && motion == false) {
            endpoint = transform.position.z + 1.1f;
            roomin = true;
            motion = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        /*--------------------------------------------------ここまで-----------------------------------------------*/

        /*------------------------------------------エレベータに潰される-------------------------------------------*/

        if (co.gameObject.tag == "Return") des_1 = true;
        if (co.gameObject.tag == "Death") des_2 = true;
        if (co.gameObject.tag == "OnElv") des_4 = true;
    }

    void OnCollisionStay(Collision co)
    {

        



    }

    void OnCollisionExit(Collision co) {
        
    }

    /*------------------------------------------------ここまで-----------------------------------------------------*/

    void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.tag == "UnElv") des_3 = true;
        else des_3 = false;

        if (co.gameObject.tag == "EBullet") {
            Destroy(co.gameObject);
            dam = true;
            Dmgcnt2++;
            if (Dmgcnt2 % 2 == 1) HP--;

        }
        
        if (co.gameObject.tag == "ESubBullet") {
            Destroy(co.gameObject);
            dam = true;
            Dmgcnt++;
            if (Dmgcnt % 4 == 1) HP--;
        }
        
        if(co.gameObject.tag == "Wepon1") {
            ChangeWepon.PreNum = ChangeWepon.Num;
            ChangeWepon.Num = 1;
            wepon = 1;
        }
        if (co.gameObject.tag == "Wepon2") {
            ChangeWepon.PreNum = ChangeWepon.Num;
            ChangeWepon.Num = 2;
            wepon = 2;
        }
        if (co.gameObject.tag == "Exit") exit = true;
        if (co.gameObject.tag == "Goal") goal = true;
        if (co.gameObject.tag == "RedDoor") {
            SCOREP = true;
            gameObject.layer = LayerMask.NameToLayer("Roll");
        }
        if (co.gameObject.tag == "RedDoor2") {
            SCOREP2 = true;
            gameObject.layer = LayerMask.NameToLayer("Roll");
        }
        if (co.gameObject.tag == "RedDoor3") {
            gameObject.layer = LayerMask.NameToLayer("Roll");
            SCOREP3 = true;
        }
        if (co.gameObject.tag == "RedDoor4") {
            gameObject.layer = LayerMask.NameToLayer("Roll");
            SCOREP4 = true;
        }
        if (co.gameObject.tag == "end") animator.SetBool("is_fall", false);


    }

    void OnTriggerExit(Collider co) {
        if (co.gameObject.tag == "Exit") exit = false;
        if (co.gameObject.tag == "Return") des_1 = false;
        if (co.gameObject.tag == "Death") des_2 = false;
        if (co.gameObject.tag == "OnElv") des_4 = false;

        if (co.gameObject.tag == "RedDoor") {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        if (co.gameObject.tag == "RedDoor2") {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        if (co.gameObject.tag == "RedDoor3") {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        if (co.gameObject.tag == "RedDoor4") {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }

}
