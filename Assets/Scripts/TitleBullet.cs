using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBullet : MonoBehaviour {
    
    public GameObject end;
    public static Vector3 startPos; // 初期位置座標
    public Vector3 endpos;
    

    // Use this for initialization
    void Start() {
        startPos = transform.position; // 初期位置を代入
        endpos = end.transform.position;
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position; // 現在の座標
        // 線形補間を使って徐々にスライドさせる
        pos.x = Mathf.Lerp(pos.x, endpos.x, Time.deltaTime * 2f);
        pos.y = Mathf.Lerp(pos.y, endpos.y, Time.deltaTime * 2f);

        transform.position = pos; // 座標を指定
    
    }
}
