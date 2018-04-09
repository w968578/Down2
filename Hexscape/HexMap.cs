using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// audiohifi... in diberville
public class HexMap : MonoBehaviour {

    // Use this for initialization
    void Start() {
        //GenerateMap();
        
    }

    public GameObject HexPrefab;

    public Mesh meshWater;
    public Mesh meshFlat;
    public Mesh meshHill;
    public Mesh meshMountain;

    // changed in video 3
    // public Material[] HexMaterials;

    public Material matOcean;
    public Material matLake;
    public Material matPlains;
    public Material matMountain;
    public Material matDesert;
    public Material matGrassland;
    public Material matWasteland;

    // my change to get the tiles back
    public Material[] HexMaterials = new Material[7];
    

    public int cols = 50;
    public int rows = 15;
    private int x_offset = 0;
    virtual public void GenerateMap()
    {
        // generates a water world
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                x_offset = (int)(row / 2);
                Hex h = new Hex(col - x_offset, row);
                //Vector3 pos = h.PositionFromCamera(Camera.main.transform.position, rows, cols);

                GameObject HexOB = (GameObject) Instantiate(
                    HexPrefab,
                    h.Position(),
                    Quaternion.identity,
                    this.transform);

                HexOB.transform.SetParent(this.transform);
                //HexOB.GetComponent<HexComponent>().Hex = h;
                //HexOB.GetComponent<HexComponent>().HexMap = this;
                //HexOB.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", col, row);

                MeshRenderer mr = HexOB.GetComponentInChildren<MeshRenderer>();
                //changed in video 3
                // changed back for me
                // mr.material = HexMaterials[Random.Range(0, HexMaterials.Length)];
                mr.material = matDesert;

                // all of the meshes are the same... for now.
                MeshFilter mf = HexOB.GetComponentInChildren<MeshFilter>();
                mf.mesh = meshWater;
            }
        }
    }
}
