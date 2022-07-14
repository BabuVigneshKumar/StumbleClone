using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
	public GameObject player;
	public Vector3 velocity;
	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
		
	}
	
 private void OnCollisionEnter(Collision other)
  {
		
		if(other.collider.CompareTag("Player"))
		{
			other.rigidbody.AddForce(Vector3.up*other.rigidbody.mass*10,ForceMode.Impulse);
		}
	}
}
