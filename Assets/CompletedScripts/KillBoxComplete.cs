using UnityEngine;
using System.Collections;

public class KillBoxComplete : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D colliderHit)
	{
		if(colliderHit.CompareTag("Ball"))
		{
			Destroy(colliderHit.gameObject);
		}
	}
}
