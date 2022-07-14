using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
	 [Header("Camera Follow")]
	public Transform targetObjet;
	public Vector3 cameraOffset;
	public float SmoothTime = 2f;
	public bool lookAtTarget = false;	
	 void Start()
	{
		cameraOffset = transform.position - targetObjet.transform.position;
	}
	private void LateUpdate()
	{
		Vector3 newPosition = targetObjet.transform.position + cameraOffset;
		transform.position = Vector3.Slerp(transform.position, newPosition, SmoothTime);
	
		if(lookAtTarget)
		{
			transform.LookAt(targetObjet);
		}   
	}
}