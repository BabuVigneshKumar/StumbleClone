using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Mirror;

[RequireComponent(typeof(CapsuleCollider),typeof(Rigidbody))]

public class PlayerController : NetworkBehaviour 
{

	[Header("Jump")]
	
	 public Transform GroundPoint;
	 public bool IsGrounded; 
	  public bool IsSliding;
	 public LayerMask GroundLayer;
	 
	[SerializeField]
	private float movespeed = 5f;
	[SerializeField]
	private float gravity = 9.81f;
	[SerializeField]
	private float jumpSpeed = 1f;
	[Header("Anime")]
	public Animator anim;
	private  float  directionY;
	Vector3  direction;
	 public float force = 300f;
	 
	 public float pushforce = 90f;
	[Header("Camera")]
	float angle = 180;
	
	Camera cam;

	 

	[Header("Joysticks")]
	[SerializeField] private Rigidbody rb;
	[SerializeField] private FixedJoystick joyStick;
	[SerializeField] private float moveSpeed;
	[SerializeField] private static PlayerController instance;
	 
	private void Awake()
	{
		joyStick = GameManager.instance.JoystickMove;
		ScreenTouch.instance.Target = this.transform;
		instance = this;
		
		 cam = Camera.main;
	}
	void Start() 
	   {	  	
		 
		
			UIHandler.instance.JumpButton.onClick.AddListener(jummpy);
		
	   }
	
	 void FixedUpdate() {
					
		// rb.velocity=new Vector3 (joyStick.Horizontal*moveSpeed,rb.velocity.y,joyStick.Vertical*moveSpeed);
		
		// if (joyStick.Horizontal !=0||joyStick.Vertical!=0)
		// {		
		//   transform.rotation=Quaternion.LookRotation(rb.velocity);
		// }	
		Vector3 xdir = cam.transform.forward * joyStick.Direction.y;
		Vector3 zdir = cam.transform.right * joyStick.Direction.x;
		Vector3 finalvelocity = xdir+ zdir;
		finalvelocity.y = IsGrounded ? 0 : Physics.gravity.y;
		finalvelocity.y = rb.velocity.y;
		rb.velocity = new Vector3(finalvelocity.x * moveSpeed, finalvelocity.y, finalvelocity.z * moveSpeed);
		 rb.velocity = finalvelocity*moveSpeed;

		if (joyStick.Horizontal != 0 || joyStick.Vertical != 0)
		{   
			transform.rotation = Quaternion.LookRotation(rb.velocity);


		}
		
		anim.SetBool("Run", joyStick.Horizontal !=0||joyStick.Vertical!=0);
		GroundCheck();					
	}
	   void GroundCheck()
		 {
		 	Collider[] ground = Physics.OverlapSphere(GroundPoint.position, 0.1f, GroundLayer);
			
			if (ground.Length == 0)
			{
				IsGrounded = false;
			}
			else
			{
				IsGrounded = true;
				IsSliding = false;
				direction = Vector3.zero;
			}
			
			anim.SetBool("Jumping Up", !IsGrounded);
			anim.SetBool("Slide",IsSliding);
				
		 }
	
	
	public void jummpy()
	{
		
				if (IsGrounded)
				{
					Debug.LogWarning("Button working");
						
					rb.AddForce(Vector3.up*force,ForceMode.Impulse);
				}
				else if(!IsSliding)
				{
					Debug.LogError("Double click working");
					rb.AddForce(transform.forward*pushforce,ForceMode.Impulse);
					Debug.Log(this.transform.position);
					IsSliding = true;
				
			
			directionY -= gravity*Time.deltaTime;
			direction.y = directionY;
		
				}
	
	
	}
}
	
