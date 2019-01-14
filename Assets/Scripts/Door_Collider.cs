using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Collider : MonoBehaviour
{
    Door D = new Door();
    public GameObject door;
    private int cnt = 1;
    private bool open = false;
    private int ecnt = 1;
    private bool eopen = false;
    private int dcnt = 1;
    private bool dopen = false;


    void OnTriggerStay(Collider co)
    {
        if (co.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.A) && cnt == 1 && this.gameObject.tag == "Red")
        {
            cnt++;
            D.Do(true, door);
            open = true;
        }
        if (co.gameObject.tag == "Enemy" && ecnt == 1)
        {
            ecnt++;
            D.Do(true, door);
            eopen = true;
        }
        if (co.gameObject.tag == "Enemy_destroy" && dcnt == 1)
        {
            dcnt++;
            D.Do(true, door);
            dopen = true;
        }
    }

    void OnTriggerExit(Collider co)
    {
        if (co.gameObject.tag == "Player" && open == true && this.gameObject.tag == "Red")
        {
            D.Do(false, door);
            cnt = 1;
            open = false;
        }
        if (co.gameObject.tag == "Enemy" && eopen == true)
        {
            D.Do(false, door);
            ecnt = 1;
            eopen = false;
        }
        if (co.gameObject.tag == "Enemy_destroy" && dopen == true)
        {
            D.Do(false, door);
            dcnt = 1;
            dopen = false;
        }
    }
}
