using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_limit : MonoBehaviour
{
    GameObject Player;
    GameObject wall_Left;
    GameObject wall_Right;
    GameObject wall_Bottom;
    GameObject wall_Top;

    Vector3 LeftPos;
    Vector3 RightPos;
    Vector3 BottomPos;
    Vector3 TopPos;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("helcopter_idle_blend1");
        wall_Left = GameObject.Find("Wall_l");
        wall_Right = GameObject.Find("Wall_r");
        wall_Bottom = GameObject.Find("Wall_b");
        wall_Top = GameObject.Find("Wall_t");

        LeftPos = wall_Left.transform.position;
        RightPos = wall_Right.transform.position;
        BottomPos = wall_Bottom.transform.position;
        TopPos = wall_Top.transform.position;

    }

    // Update is called once per frame
    void Update ()
    {
        Player.transform.position = (new Vector3(Mathf.Clamp(Player.transform.position.x, LeftPos.x - 10, RightPos.x + 10),
               Mathf.Clamp(Player.transform.position.y, BottomPos.y + 10, TopPos.y - 10), transform.position.z));
    }
}
