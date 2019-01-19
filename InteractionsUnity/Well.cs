using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : Interactable
{
	private ParticleSystem parts;
	

	void Start()
	{
		
		parts = GetComponent<ParticleSystem>();
	}
	
	public override void Interact()
	{		
		//you could also have playerHealth ++ in here
		Debug.Log("You drank water from the well");
		parts.Play();
	}
	
}
