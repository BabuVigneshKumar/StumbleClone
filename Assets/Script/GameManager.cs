using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
	public FixedJoystick JoystickMove;
	public ScreenTouch screenTouch;
	public static GameManager instance;
	public Transform Target;
	
	
	
	private void Awake() 
	{
		instance = this;
	}
	
	
}
