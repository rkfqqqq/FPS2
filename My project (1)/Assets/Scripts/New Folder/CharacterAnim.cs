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
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("IsRunning", true);
                if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
                {
                    anim.SetBool("IsSprinting", true);
                }
                if (Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKeyUp(KeyCode.W))
                {
                    anim.SetBool("IsSprinting", false);
                }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("IsRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("IsGoingBack", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("IsGoingBack", false);
        }
       
    }
    
}
