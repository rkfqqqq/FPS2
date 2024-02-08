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
        if (Input.GetKeyDown("w") || Input.GetKeyDown("s") || Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
            anim.SetBool("IsRunning", true);
            AnimDebug += 1;
            Debug.Log(AnimDebug);
        }
        else
        {
            anim.SetBool("IsRunning", false);
            Debug.Log(AnimDebug);
        }
    }
    
}
