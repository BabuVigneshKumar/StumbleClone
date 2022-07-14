using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouch : MonoBehaviour
{
	
	private float Yaxis ;
	private float Xaxis;
	public float xMinLimit = 0f;
	public float xMaxLimit = 50f;
	public float RotationSensitivity =5f;
	public Transform Target;
	private Vector3 initalOffset;
	private Vector3 cameraPosition;
	public static ScreenTouch instance;
  
	void Start()
	{
	  
		initalOffset = this.transform.localPosition;
	   
	}
	private void Awake()
	{
		instance = this;
	}
  
	public void CameraSnap()

	{
		
		initalOffset = transform.position - Target.position;

		Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
		Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
		Xaxis = ClampAngle(Xaxis, xMinLimit, xMaxLimit);
		Vector3 TargetRotaion = new Vector3(Xaxis, Yaxis);

		transform.eulerAngles = TargetRotaion;
		transform.position = Target.position - transform.forward * 14.65f;
	}
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
	private void FixedUpdate()
	{
	
		if(Target.CompareTag("Player")){
			cameraPosition=Target.position+initalOffset;
			transform.position=cameraPosition;
		}
	}
	}