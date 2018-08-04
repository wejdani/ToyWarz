using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelTeddyController : MonoBehaviour {

    public GameObject CottonBallprojectile;
    public float projectileSpeed;

    public Animator animator;
    private float inputH;
    private float inputV;
    public Rigidbody rbody;
    private bool run;

     void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        run = false; 
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        // {
        //shoot();

        //}
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        animator.SetFloat("inputH", inputH);
        animator.SetFloat("inputV", inputV);
        animator.SetBool("run", run);
        float moveX = inputH * 20f * Time.deltaTime; 
        float moveZ = inputV * 50f * Time.deltaTime; 

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        if(moveZ<=0){
            moveX = 0;
        }
        if(run){
            moveX *= 3f;
            moveZ *= 3f;
        }
        rbody.velocity = new Vector3(moveX, 0, moveZ);

    }

    void shoot() {
        GameObject cottonBall = Instantiate(CottonBallprojectile, transform) as GameObject;
        Rigidbody rb = cottonBall.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projectileSpeed;
    }
}
