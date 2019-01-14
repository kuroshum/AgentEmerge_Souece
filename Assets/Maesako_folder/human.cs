using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class human : MonoBehaviour
{
    public Animator walk;
    public Animator Squat;
    public Animator Gun;
    public Animator SG;
    public Animator Roll;
    public Animator Fi;
    public Text x;
    public int count = 0;
    public int cnt = 0;

    // Use this for initialization
    void Start ()
    {
        walk = GetComponent<Animator>();
        walk.SetBool("walk", false);
        Squat = GetComponent<Animator>();
        Squat.SetBool("squat", false);
        Gun = GetComponent<Animator>();
        Gun.SetBool("gun", false);
        SG = GetComponent<Animator>();
        SG.SetBool("squat_gun", false);
        Roll = GetComponent<Animator>();
        Roll.SetBool("rolling", false);
        Fi = GetComponent<Animator>();
        Fi.SetBool("finish", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("return"))
        {

            if (cnt == 0)
            {
                x.text = "";
                cnt = 100;
            }
            else if (cnt == 100)
            {
                x.text = "";
                cnt = 99;
            }
            else if (cnt == 99)
            {
                x.text = "";
                cnt = 97;
            }
            else if (cnt == 97)
            {
                x.text = "";
                cnt = 96;
            }
            else if (cnt == 96)
            {
                x.text = "";
                cnt = 95;
            }
            else if (cnt == 95)
            {
                x.text = "";
                cnt = 94;
            }
            else if (cnt == 94)
            {
                x.text = "";
                cnt = 93;
            }
            else if (cnt == 93)
            {
                x.text = "";
                cnt = 92;
            }
            else if (cnt == 92)
            {
                x.text = "";
                cnt = 91;
            }
            else if (cnt == 91)
            {
                x.text = "";
                cnt = 90;
            }
            else if (cnt == 90)
            {
                x.text = "";
                cnt = 89;
            }
            else if (cnt == 89)
            {
                walk.SetBool("walk", true);
                cnt = 1;
            }
            else if (cnt == 1)
            {
                Squat.SetBool("squat", true);
                cnt = 2;
            }
            else if (cnt == 2)
            {
                Gun.SetBool("gun", true);
                cnt = 3;
            }
            else if (cnt == 3)
            {
                SG.SetBool("squat_gun", true);
                cnt = 4;
            }
            else if (cnt == 4)
            {
                Roll.SetBool("rolling", true);
                cnt = 5;
            }
            else if (cnt == 5)
            {
                Fi.SetBool("finish", true);
            }

        }
	}

   // IEnumerator Loop()
    //{
       // for (count = 0; count <= 9; count++)
       // {
         //   while (!Input.GetKeyDown("return"))
         //   {
         //       yield return 0;
         //   }
        //    yield return new WaitForSeconds(0.1f);
      //  }
  //  }  
}
