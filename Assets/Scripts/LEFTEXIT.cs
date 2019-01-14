using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEFTEXIT : MonoBehaviour {

    public float distance; // スライドする長さ
    public float length; // 反応する距離

    private Vector3 RstartPos; // 初期位置座標
    private Vector3 LstartPos;
    private Transform player; // プレイヤー座標

    // Use this for initialization
    void Start() {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RstartPos = ExitController.startPos; // 初期位置を代入
        LstartPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position; // 現在の座標

        // プレイヤーが一定の距離に近づいたら
        if (ExitController.left) {
            // 線形補間を使って徐々にスライドさせる
            pos.x = Mathf.Lerp(pos.x, LstartPos.x - distance, Time.deltaTime * 5f);
        }
        else {
            // 元の位置に戻る
            pos.x = Mathf.Lerp(pos.x, LstartPos.x, Time.deltaTime * 5f);
        }

        transform.position = pos; // 座標を指定
    }
}
