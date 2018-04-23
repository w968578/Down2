using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();
                // mr.material.color = Color.red;
                // Debug.Log("Test: " + ourHitObject.GetComponentInChildren<TextMesh>().text);

                ///////
                //This code makes it so I can change the color of the tile by clicking it
                ///////
                Color c = mr.material.color;
                if (c == Color.red)
                {
                    mr.material.color = Color.yellow;
                }
                else if (c == Color.yellow)
                {
                    mr.material.color = Color.green;
                }
                else if (c == Color.green)
                {
                    mr.material.color = Color.cyan;
                }
                else if (c == Color.cyan)
                {
                    mr.material.color = Color.blue;
                }
                else if (c == Color.blue)
                {
                    mr.material.color = Color.magenta;
                }
                else if (c == Color.magenta)
                {
                    mr.material.color = Color.white;
                }
                else if (c == Color.white)
                {
                    mr.material.color = Color.black;
                }
                else
                {
                    mr.material.color = Color.red;
                }


                //if (mr.material == matOcean)
                //{
                //    mr.material = matLake;
                //}
                //else if (mr.material == matLake)
                //{
                //    mr.material = matDesert;
                //}
                //else if (mr.material == matDesert)
                //{
                //    mr.material = matPlains;
                //}
                //else if (mr.material == matPlains)
                //{
                //    mr.material = matGrassland;
                //}
                //else if (mr.material == matGrassland)
                //{
                //    mr.material = matMountain;
                //}
                //else if (mr.material == matMountain)
                //{
                //    mr.material = matWasteland;
                //}
                //else
                //{
                //    mr.material = matOcean;
                //}
            }
        }
	}
}
