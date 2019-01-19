using UnityEngine;
using UnityEngine.EventSystems;


public class Interactable : MonoBehaviour
{

	//Place this script on your player camera
	
	#region Class Variables, Update


    	private RaycastHit hit;
		private GameObject rayCastObject;
	[Tooltip("Interaction Distance")]
	[SerializeField] private float rayLength = 6f;
    	
    
    	void Update()
	    {
		    //this makes sure you aren't hitting any ui elements in game
		    if (EventSystem.current.IsPointerOverGameObject())
			    return;
		    
		    //the reason i used a seperate method is purely by choice
		    //i like to have my update methods as clean as possible and easy to follow
    		MouseHitOperations();
    		
    	}

	#endregion


	#region RayCastHit and Interactions

		void MouseHitOperations()
		{
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
    		//start,direction,ray,distance,mask
    		if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
		    {
			    //whatever the ray hits determines the focused object i.e. Door with Door : interactable script
			    rayCastObject = hit.collider.gameObject;
			    Interactable interactable = rayCastObject.GetComponent<Interactable>(); 	
    			
			    // "Interaction" is set up on my pc as keyboard button E.
			    //This can be changed to anything in player input settings in unity.
    			if (Input.GetButtonDown("Interaction") && interactable != null)
    			{				   
				    interactable.Interact();
    			}
       			
    		}
    	}

	public virtual void Interact()
	{
		//this will be called on the individual objects
		//the interactable child class will override this
	}
        	
	#endregion


	#region Helper Methods

	//calculates how far away an object is from the player if needed.
//	private float Distance()
//    	{
//    		return Vector3.Distance(t.position, player.position);
//    	}

	// draws in editor wire sphere to show radius if needed.
//    	void OnDrawGizmosSelected()
//    	{
//    		Gizmos.color = objectGizmoColor;
//    		Gizmos.DrawWireSphere(transform.position, radius);
//    	}

	#endregion
	
}
	
	
