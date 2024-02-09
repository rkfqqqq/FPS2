using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator anim;
    public int AnimDebug = 0;
    void Start()
    {
         anim = GetComponent<Animator>();

    }
    void Update()
    {
        if (Input.GetKeyDown("w") && !Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("IsRunning", true);

        }
        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("IsRunning", false);

        }
     if (Input.GetKeyDown("s"))
        {
            anim.SetBool("IsGoingBack", true);
        }
        if (Input.GetKeyUp("s"))
        {
            anim.SetBool("IsGoingBack", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown("w"))
        {
            anim.SetBool("IsSprinting", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKeyUp("w"))
        {
            anim.SetBool("IsSprinting", false);
        }
    }
    
}
