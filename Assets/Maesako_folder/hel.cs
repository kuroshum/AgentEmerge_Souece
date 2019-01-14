using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hel : MonoBehaviour
{
    public bool CanMove = true;
    public bool CanMoveForward = true;
    public bool CanMoveBack = true;
    public bool CanMoveLeft = true;
    public bool CanMoveRight = true;
    public bool CanMoveUp = true;
    public bool CanMoveDown = true;
    public bool CanRotateYaw = true;
    public bool CanRotatePitch = true;
    public bool CanRotateRoll = true;
    public GameObject h;
    public GameObject left_limit;
    public GameObject right_limit;
    public GameObject upper_limit;
    public GameObject bottom_limit;
    public GameObject back_limit;
    public GameObject front_limit;

    public float MovementSpeed = 100f;
    public float RotationSpeed = 100f;

    private bool canTranslate;
    private bool canRotate;

    // Use this for initialization
    void Start ()
    {
        canTranslate = CanRotateYaw || CanRotatePitch || CanRotateRoll;
        canRotate = CanMoveForward || CanMoveBack || CanMoveRight || CanMoveLeft || CanMoveUp || CanMoveDown;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        if (canTranslate)
        {
            // Check key input
            int[] input = new int[6]; // Forward, Back, Left, Right, Up, Down
            if (CanMoveForward && Input.GetKey(KeyCode.F11))
            {
                input[0] = 4;
            }
            else if (CanMoveBack && Input.GetKey(KeyCode.F12))
            {
                input[1] = 4;
            }
            if (CanMoveLeft && Input.GetKey(KeyCode.LeftArrow))
            {
                input[2] = 4;
            }
            else if (CanMoveRight && Input.GetKey(KeyCode.RightArrow))
            {
                input[3] = 4;
            }
            if (CanMoveUp && Input.GetKey(KeyCode.UpArrow))
            {
                input[4] = 3;
            }
            else if (CanMoveDown && Input.GetKey(KeyCode.DownArrow))
            {
                input[5] = 5;
            }
            int numInput = 0;
            for (int i = 0; i < 6; i++)
            {
                numInput += input[i];
            }
            // Add velocity to the gameobject
            float curSpeed = numInput > 0 ? MovementSpeed : 0;
            Vector3 AddPos = input[0] * Vector3.forward + input[2] * Vector3.left + input[4] * Vector3.up
                + input[1] * Vector3.back + input[3] * Vector3.right + input[5] * Vector3.down;
            AddPos = GetComponent<Rigidbody>().rotation * AddPos;
            GetComponent<Rigidbody>().velocity = AddPos * (Time.fixedDeltaTime * curSpeed);

            h.transform.position = (new Vector3(Mathf.Clamp(h.transform.position.x, left_limit.transform.position.x, right_limit.transform.position.x),
                Mathf.Clamp(h.transform.position.y, bottom_limit.transform.position.y, upper_limit.transform.position.y),
                Mathf.Clamp(h.transform.position.z, back_limit.transform.position.z, front_limit.transform.position.z)));
        }
    }
}
