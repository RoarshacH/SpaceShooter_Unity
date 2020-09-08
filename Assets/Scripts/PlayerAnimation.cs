using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.A))) {
            anim.SetBool("turnLeft", true);
            anim.SetBool("turnRight", false);
        }
        if((Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.A))) {
            anim.SetBool("turnLeft", false);
            
        }


        if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.D)))
        {
            anim.SetBool("turnRight", true);
            anim.SetBool("turnLeft", false);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow)) || (Input.GetKeyUp(KeyCode.D)))
        {
            anim.SetBool("turnRight", false);
        }
    }
}
