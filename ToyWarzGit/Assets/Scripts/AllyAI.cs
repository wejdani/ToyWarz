﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAI : PlayerKeyboardMovements
{

    public float targetDistance;
    public float allowedDistance;
    public float miniDistance = 1.9f;
    public Transform myTrans;
    static Animator ani;
    static UnityEngine.AI.NavMeshAgent nav;
    public bool isAlive = true;
    private Vector3 direction;
    private float angle;
    private Vector3 angelTeddyCurrPos;
    private bool isMoving;

    private void Start()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        angelTeddyCurrPos = GameObject.FindWithTag("Player").transform.position;
        isMoving = true;
        allowedDistance = 20f;

    }

    // Update is called once per frame
    void Update()
    {
        //distanceCal(target);
        if (isMoving)
            playerMoved();
        else
           distanceCal();
    }

    // Detect and Follow The Enemies to Attack Them
    protected void distanceCal()
    {


        if (GameObject.FindWithTag("Cat") && isAlive)
        {
            nav.SetDestination(GameObject.FindWithTag("Cat").transform.position);
            direction = GameObject.FindWithTag("Cat").transform.position - this.transform.position;
            angle = Vector3.Angle(direction, this.transform.forward);
            targetDistance = Vector3.Distance(GameObject.FindWithTag("Cat").transform.position, myTrans.transform.position);

            direction.y = 0;


            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);

            if (targetDistance <= allowedDistance && targetDistance > miniDistance && angle < 90)
            {


                ani.SetBool("isIdle", false);
                ani.SetBool("isWalking", true);

                transform.Translate(Vector3.forward * nav.speed * Time.deltaTime);
                nav.speed = 1.5f;
            }
            else if (targetDistance <= miniDistance)
            {


                ani.SetBool("isIdle", false);
                ani.SetBool("isWalking", false);
                ani.SetBool("isAttacking", true);

                transform.Translate(Vector3.forward * nav.speed * Time.deltaTime);
                nav.speed = 0f;
            }
            else
            {
                nav.speed = 0f;
                ani.SetBool("isIdle", true);
                ani.SetBool("isWalking", false);
                ani.SetBool("isAttacking", false);
            }
        }
        else if (GameObject.FindWithTag("Duck") && isAlive)
        {
            nav.SetDestination(GameObject.FindWithTag("Duck").transform.position);
            direction = GameObject.FindWithTag("Duck").transform.position - this.transform.position;
            angle = Vector3.Angle(direction, this.transform.forward);
            targetDistance = Vector3.Distance(GameObject.FindWithTag("Duck").transform.position, myTrans.transform.position);

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);
            
            if (targetDistance <= allowedDistance && targetDistance > miniDistance && angle < 90)
            {


                ani.SetBool("isIdle", false);
                ani.SetBool("isAttacking", false);
                ani.SetBool("isWalking", true);

                transform.Translate(Vector3.forward * nav.speed * Time.deltaTime);
                nav.speed = 1.5f;
            }
            else if (targetDistance <= miniDistance)
            {


                ani.SetBool("isIdle", false);
                ani.SetBool("isWalking", false);
                ani.SetBool("isAttacking", true);

                transform.Translate(Vector3.forward * nav.speed * Time.deltaTime);
                nav.speed = 0f;
            }
            else
            {
                nav.speed = 0f;
                ani.SetBool("isIdle", true);
                ani.SetBool("isWalking", false);
                ani.SetBool("isAttacking", false);
            }
        }
        else if (GameObject.FindWithTag("Bear") && isAlive)
        {
            nav.SetDestination(GameObject.FindWithTag("Bear").transform.position);
            direction = GameObject.FindWithTag("Bear").transform.position - this.transform.position;
            angle = Vector3.Angle(direction, this.transform.forward);
            targetDistance = Vector3.Distance(GameObject.FindWithTag("Bear").transform.position, myTrans.transform.position);

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);

            if (targetDistance <= allowedDistance && targetDistance > miniDistance && angle < 90)
            {


                ani.SetBool("isIdle", false);
                ani.SetBool("isAttacking", false);
                ani.SetBool("isWalking", true);

                transform.Translate(Vector3.forward * nav.speed * Time.deltaTime);
                nav.speed = 1.5f;
            }
            else if (targetDistance <= miniDistance)
            {


                ani.SetBool("isIdle", false);
                ani.SetBool("isWalking", false);
                ani.SetBool("isAttacking", true);

                transform.Translate(Vector3.forward * nav.speed * Time.deltaTime);
                nav.speed = 0f;
            }
            else
            {
                nav.speed = 0f;
                ani.SetBool("isIdle", true);
                ani.SetBool("isWalking", false);
                ani.SetBool("isAttacking", false);
            }
        }
        else
        {
            ani.SetBool("isIdle", true);
            ani.SetBool("isWalking", false);
            ani.SetBool("isAttacking", false);
        }


    }

    private void playerMoved()

    {
        if (angelTeddyCurrPos.x < GameObject.FindWithTag("Player").transform.position.x
            || angelTeddyCurrPos.x > GameObject.FindWithTag("Player").transform.position.x
            || angelTeddyCurrPos.z < GameObject.FindWithTag("Player").transform.position.z
            || angelTeddyCurrPos.z > GameObject.FindWithTag("Player").transform.position.z)
        {
            ani.SetBool("isIdle", false);
            ani.SetBool("isWalking", true);
            isMoving = false;
        }
    }
}
