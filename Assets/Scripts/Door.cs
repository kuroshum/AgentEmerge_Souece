using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public void Do(bool d,GameObject door)
    {
        if (d)
        {
            door.transform.Rotate(0, 90, 0);
            //Debug.Log("open");
        }
        else
        {
            door.transform.Rotate(0, -90, 0);    
            //Debug.Log("Close");
        }
    }

   
}
