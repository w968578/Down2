using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemies : MonoBehaviour {
    private Vector3 moveUpLeft = new Vector3(-(Mathf.Sqrt(3) / 2), 0, 1.5f);
    private Vector3 moveUpRight = new Vector3((Mathf.Sqrt(3) / 2), 0, 1.5f);
    private Vector3 moveDownLeft = new Vector3(-(Mathf.Sqrt(3) / 2), 0, -1.5f);
    private Vector3 moveDownRight = new Vector3((Mathf.Sqrt(3) / 2), 0, -1.5f);
    private Vector3 moveLeft = new Vector3(-(Mathf.Sqrt(3)), 0, 0);
    private Vector3 moveRight = new Vector3((Mathf.Sqrt(3)), 0, 0);
    public GameObject darkLord;
    private Vector3 defaultSize = new Vector3(1f,1f,1f);

    //Basic movement vectors
    private bool occupied = false;
    

    //make an array of game objects DRR
    public GameObject[] enemyCadre = new GameObject[6];

    private int RandoW()
    {
        return Random.Range(1, 10);
    }
    private int RandoL()
    {
        return Random.Range(1, 10);
    }

    private int RandMvmtGen()
    {
        return Random.Range(0, 6);
    }


    // Use this for initialization
    void Start()
    {
        //Making a loop that will initialize an army DRR

        for (int i = 0; i < enemyCadre.Length; i++)
        {
            GameObject darklord = Instantiate(darkLord);
            darkLord.transform.position = new Vector3(RandoW() * (Mathf.Sqrt(3)), 0, 1.5f *RandoL());
            if((darkLord.transform.position.z / 1.5f)%2 == 1)
            {
                darkLord.transform.position +=  new Vector3(0,0,1.5f);
            }
            //if ((lord.transform.position.x / Mathf.Sqrt(3))%2 == 1)
            //{
            //    lord.transform.position += new Vector3((Mathf.Sqrt(3))/2, 0, 0);
            //}
            //for (int j = 0; j < Variables.army.Length; j++)
            //{
            //    if (Variables.army[j].transform.position == lord.transform.position)
            //    {
            //        occupied = true;
            //    }
            //    if (occupied)
            //    {
            //        lord.transform.position = new Vector3(RandoW() * (Mathf.Sqrt(3)), 0, RandoL());
            //    }
            //    occupied = false;
            //}
            enemyCadre[i] = darkLord;
        }
    }
    public void MoveEnemies()
    {
        enemyCadre[0].transform.position += moveUpLeft;

        for (int i = 0; i < enemyCadre.Length; i++)
        {
            int rand = RandMvmtGen();
            if (rand == 0)
            {
               enemyCadre[i].transform.position += new Vector3(0, 0, 1);
                print(rand);
            }
            if (rand == 1)
            {
                enemyCadre[i].transform.position += moveUpRight;
                print(rand);
            }
            if (rand == 2)
            {
               enemyCadre[i].transform.position += moveDownLeft;
                print(rand);
            }
            if (rand == 3)
            {
                enemyCadre[i].transform.position += moveDownRight;
                print(rand);
            }
            if (rand == 4)
            {
                enemyCadre[i].transform.position += moveLeft;
                print(rand);
            }
            if (rand == 5)
            {
                enemyCadre[i].transform.position += moveRight;
                print(rand);
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
