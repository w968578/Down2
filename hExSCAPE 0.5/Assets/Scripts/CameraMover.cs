using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    Vector3 oldPosition;

    // Use this for initialization
    void Start () {
        oldPosition = this.transform.position;
	}
    
	// Update is called once per frame
	void Update () {
        // click and drag settings
        // WADS
        // zoom in / out

        DidCameraMove();
	}
    HexComponent[] hexes;
    void DidCameraMove()
    {
        if (oldPosition != this.transform.position)
        {
            // camera was moved
            oldPosition = this.transform.position;

            // build a dictionary listing in hexmap instead of using findobjectsoftype<>
            if (hexes == null)
                hexes = GameObject.FindObjectsOfType<HexComponent>();

            foreach(HexComponent hex in hexes)
            {
                hex.UpdatePosition();
            }
        }

    }
}
