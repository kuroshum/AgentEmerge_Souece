using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {

    public float distance; // スライドする長さ
    public float length; // 反応する距離
    public static bool left;
    public GameObject LeftExit;
    public static Vector3 startPos; // 初期位置座標
    public Vector3 LeftPos;
    private Transform player; // プレイヤー座標
    
    // Use this for initialization
    void Start() {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        LeftPos = LeftExit.transform.position;
        startPos = transform.position; // 初期位置を代入
    }

    // Update is called once per frame
    void Update() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 pos = transform.position; // 現在の座標
        Vector3 lpos = LeftExit.transform.position;

        // プレイヤーが一定の距離に近づいたら
        if (Vector3.Distance(player.position, startPos) <= length && Player_controller2.exit) {
            // 線形補間を使って徐々にスライドさせる
            pos.x = Mathf.Lerp(pos.x, startPos.x + distance, Time.deltaTime * 5f);
            lpos.x = Mathf.Lerp(lpos.x, LeftPos.x - distance, Time.deltaTime * 5f);
            left = true;
        }
        else {
            // 元の位置に戻る
            pos.x = Mathf.Lerp(pos.x, startPos.x, Time.deltaTime * 5f);
            lpos.x = Mathf.Lerp(lpos.x, LeftPos.x, Time.deltaTime * 5f);
            left = false;
        }

        transform.position = pos; // 座標を指定
        LeftExit.transform.position = lpos;
    }

}
