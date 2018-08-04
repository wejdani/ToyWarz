using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelTeddyController : MonoBehaviour {

    public GameObject CottonBallprojectile;
    public float projectileSpeed;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        // {
        shoot();

        //}
    }

    void shoot() {
        GameObject cottonBall = Instantiate(CottonBallprojectile, transform) as GameObject;
        Rigidbody rb = cottonBall.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projectileSpeed;
    }
}
