using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {

	
	protected float moveSpeed = 0;
	// Update is called once per frame
	void Update () {
        
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        moveSpeed = 2;
    }
}
