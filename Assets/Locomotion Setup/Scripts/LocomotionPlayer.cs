 /// <summary>
/// 
/// </summary>

using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  

//Name of class must be name of file as well

public class LocomotionPlayer : MonoBehaviour {

    protected Animator animator;

    private float speed = 0;
    private float direction = 0;
    private Locomotion locomotion = null;

	// Use this for initialization
	void Start () 
	{
        animator = GetComponent<Animator>();
        locomotion = new Locomotion(animator);
	}
    
	void Update () 
	{
        if (animator && Camera.main)
		{
           
            JoystickToEvents.Do(transform,Camera.main.transform, ref speed, ref direction);
            locomotion.Do(speed * 4, direction * 180);
		}
        //�v���C���[�̕����]��
        if (Input.GetButtonDown("Horizontal"))
        {
            transform.rotation = Quaternion.LookRotation(transform.position + (Vector3.right * Input.GetAxisRaw("Horizontal")) - transform.position);
            //transform.Rotate(new Vector3(0f, 180f, 0f));
        }
    }
}
