                                          using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
            anim.Play("kicing", -1, 0f);
        else if (Input.GetKey(KeyCode.RightArrow))
            anim.Play("walking", -1, 0f);
        else if (Input.GetKey(KeyCode.UpArrow))
            anim.Play("Jumping", -1, 0f);
        else if (Input.GetKey(KeyCode.DownArrow))
            anim.Play("dying", -1, 0f);

        if (Input.GetKeyDown("1")) {
           anim.Play("Idle", -1, 0f);
       }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("dying", -1, 0f);

        }
    }
}
