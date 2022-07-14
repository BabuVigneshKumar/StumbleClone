using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle1 : MonoBehaviour
{ 
	public float speed = 1f;
	// public float min = 1.93f;
    // public float max = -1.93f;

    void Start()
    {
        // min = transform.localPosition.x;
        // max = transform.localPosition.x + 3;
    }

    // Update is called once per frame
    void Update()
    {
		 	transform.localPosition = new Vector3(Mathf.PingPong(Time.time*speed , 3), transform.localPosition.y, transform.localPosition.z);
    }
}
