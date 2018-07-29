using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	//public GameObject Player; 
	public Transform Player;
	private UnityEngine.AI.NavMeshAgent nav ; 
	private Animator anim; 
	// Use this for initialization
	void Start () {
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		nav.speed = 1.2f; 
		anim.speed = 1.2f; 
	}
	
	// Update is called once per frame
	void Update () {


		//nav.SetDestination (Player.transform.position);
		Vector3 direction = Player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		if(Vector3.Distance(Player.position, this.transform.position) < 10 && angle < 30)
		{

			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
				Quaternion.LookRotation(direction), 0.1f);

			anim.SetBool("isIdle",false);
			if(direction.magnitude > 5)
			{
				this.transform.Translate(0,0,0.05f);
				anim.SetBool("isWalking",true);
				anim.SetBool("isAttacking",false);
			}
			else
			{
				anim.SetBool("isAttacking",true);
				anim.SetBool("isWalking",false);
			}

		}
		else 
		{
			anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
		}

	}

	void SearchForTarget(){
		Vector3 center = new Vector3 (this.transform.position.x , this.transform.position.y , this.transform.position.z);
		Collider[] hitColliders = Physics.OverlapSphere (center , 100 );
		int i = 0; 
		while(i < hitColliders.Length ){
			if(hitColliders[i].transform.tag == "Player"){

			}

		}
	}
}
