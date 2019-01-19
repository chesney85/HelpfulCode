using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Door : Interactable
{
	//for door I placed a blank state as default entry state and played my choice of anim when needed
    	//i also disabled the animator so it only runs when needed.
    	//my door animation rotates door open for 1 sec, waits 2 secs,  rotates close 1 sec.
    	//thats why i wait 4.1 secs before disabling animator again.
	
	
	private Animator anim;
	
	 void Start()
	 {
		 anim = GetComponent<Animator>();
	 }


	
	public IEnumerator doorAnim()
	{
		anim.enabled = true;
		anim.Play("DoorOpen");
		yield return new WaitForSeconds(4.1f);
		anim.enabled = false;
	}
	
	public override void Interact()
	{
		
		StartCoroutine(doorAnim());
		
	}

	
}
