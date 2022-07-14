using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchpad : MonoBehaviour
{
    public bool CanDrag;
    public ScreenTouch CameraMover;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CanDrag)
        {
            CameraMover.CameraSnap();
        }
    }

    public void CanDragCamera(int can)
    {
        CanDrag = can == 1;
    }
        
}
