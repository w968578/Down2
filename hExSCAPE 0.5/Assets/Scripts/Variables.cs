using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//25 March 2018 for Sprint 3 DRR

public class Variables : MonoBehaviour {
    //Working with strings and ints DRR
    //string gamePiece = "Archer";
    int arrowDamage = 10;
    int health = 100;

    public GameObject selectedArcher;
    public Vector3 defaultSize;
    public Vector3 selectedSize;
    private int selectedArcherPosition = 0;
    public Vector3 moveUp;
    public Vector3 moveLeft;
    public Vector3 moveRight;
    private bool occupied = false;

    //make a prefab DRR
    public GameObject archerPrefab;    
      
    //make an array of game objects DRR
   GameObject[] army = new GameObject[6];
    
    public void Shoot()
    {
        health = health - arrowDamage;

        if (health <=0)
        {
            print("You died suckaaaaaaa!");
        }
        else 
        Debug.Log("Health after being shot: " + health);
    }

    public void Heal()
    {
        health = health + Rando();
        print("Health has improved to: " + health);
    }
    private int Rando()
    {
        return Random.Range(0, 6);
    }
    // Use this for initialization
    void Start () {
        print("Health at start: " + health);

        //Making a loop that will initialize an army DRR
        for(int i = 0; i <army.Length; i++)
        {
            GameObject archer = Instantiate(archerPrefab);
            archer.transform.position = new Vector3(i*(Mathf.Sqrt(3)), 0, 0);
            archer.AddComponent<Rigidbody>().useGravity = false;
            army[i] = archer;
        }
        selectArcher(army[0]);
    }
    // Update is called once per frame, attaches meaning to button pushes
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            GetArcherLeft();
        }
        if (Input.GetKeyDown("w"))
        {
            GetArcherRight();
        }
       
        if(Input.GetKeyDown("u"))
        {
            if ((selectedArcher.transform.position.x + (-Mathf.Sqrt(3)) < -(.5f+Mathf.Sqrt(3)/2)) ||
                (selectedArcher.transform.position.z + 1.5f > 21))
            {
                print("Off the board. Illegal move. Try to move elsewhere.");
            }
            else
            {
                for (int i = 0; i < army.Length; i++)
                {
                    if (army[i].transform.position == selectedArcher.transform.position + new Vector3(-(Mathf.Sqrt(3) / 2), 0, 1.5f))
                    {
                        occupied = true;
                    }
                }
                if (!occupied)
                {
                    UpLeft(selectedArcher.transform.position);
                }
                else
                {
                    print("That tile is occupied. Try moving somewhere else.");
                }
                occupied = false;
            }
        }
        if (Input.GetKeyDown("i"))
        {
            if ((selectedArcher.transform.position.x + (Mathf.Sqrt(3)) > (.5f+ 10 * Mathf.Sqrt(3))) ||
                (selectedArcher.transform.position.z + 1.5f > 21.0f))
            {
                print("Off the board. Illegal move. Try to move elsewhere.");
            }
            else
            {
                for (int i = 0; i < army.Length; i++)
                {
                    if (army[i].transform.position == selectedArcher.transform.position + new Vector3((Mathf.Sqrt(3) / 2), 0, 1.5f))
                    {
                        occupied = true;
                    }
                }
                if (!occupied)
                {
                    UpRight(selectedArcher.transform.position);
                }
                else
                {
                    print("That tile is occupied. Try moving somewhere else.");
                }
                occupied = false;
            }
        }
        if (Input.GetKeyDown("h"))
        {

            if (selectedArcher.transform.position.x + (-Mathf.Sqrt(3)) < -0.1f)
            {
                print("Off the board. Illegal move. Try to move elsewhere.");
            }
            else
            {
                for (int i = 0; i < army.Length; i++)
                {
                    if (army[i].transform.position == selectedArcher.transform.position + new Vector3(-(Mathf.Sqrt(3)), 0, 0))
                    {
                        occupied = true;
                    }
                }
                if (!occupied)
                {
                    PushLeft(selectedArcher.transform.position);
                }
                else
                {
                    print("That tile is occupied. Try moving somewhere else.");
                }
                occupied = false;
            }
        }
        if (Input.GetKeyDown("k"))
        {
            if (selectedArcher.transform.position.x + (Mathf.Sqrt(3)) > (-.1f+ 10 * Mathf.Sqrt(3)))

            {
                print("Off the board. Illegal move. Try to move elsewhere.");
            }
            else
            {
                for (int i = 0; i < army.Length; i++)
                {
                    if (army[i].transform.position == selectedArcher.transform.position + new Vector3((Mathf.Sqrt(3)), 0, 0))
                    {
                        occupied = true;
                    }
                }
                if (!occupied)
                {
                    PushRight(selectedArcher.transform.position);
                }
                else
                {
                    print("That tile is occupied. Try moving somewhere else.");
                }
                occupied = false;
            }
        }
        if (Input.GetKeyDown("n"))
        {
            if ((selectedArcher.transform.position.x + (-Mathf.Sqrt(3)) < -(.5f + Mathf.Sqrt(3) / 2)) ||
                (selectedArcher.transform.position.z + 1.5f < 1.74f))
            {
                print("Off the board. Illegal move. Try to move elsewhere.");
            }
            else
            {
                for (int i = 0; i < army.Length; i++)
                {
                    if (army[i].transform.position == selectedArcher.transform.position + new Vector3(-(Mathf.Sqrt(3) / 2), 0, -1.5f))
                    {
                        occupied = true;
                    }
                }
                if (!occupied)
                {
                    DownLeft(selectedArcher.transform.position);
                }
                else
                {
                    print("That tile is occupied. Try moving somewhere else.");
                }
                occupied = false;
            }
        }
        if (Input.GetKeyDown("m"))
        {
            if ((selectedArcher.transform.position.x + (Mathf.Sqrt(3)) > (.5f + 10 * Mathf.Sqrt(3))) ||
               (selectedArcher.transform.position.z + 1.5f <1.74f))
            {
                print("Off the board. Illegal move. Try to move elsewhere.");
            }
            else
            {
                for (int i = 0; i < army.Length; i++)
                {
                    if (army[i].transform.position == selectedArcher.transform.position + new Vector3((Mathf.Sqrt(3) / 2), 0, -1.5f))
                    {
                        occupied = true;
                    }
                }
                if (!occupied)
                {
                    DownRight(selectedArcher.transform.position);
                }
                else
                {
                    print("That tile is occupied. Try moving somewhere else.");
                }
                occupied = false;
            }
        }
       
    }

    //This function changes the size of the selected piece so the player knows which one is selected
    void selectArcher(GameObject thisArcher)
    {
        selectedArcher.transform.localScale = defaultSize;
        selectedArcher = thisArcher;
        thisArcher.transform.localScale = selectedSize;
    }


    //These two functions allow the player to toggle between all their game pieces
    void GetArcherLeft()
    {
        if (selectedArcherPosition == 0)
        {
            selectedArcherPosition = 5;
            selectArcher(army[5]);
        }
        else
        {
            selectedArcherPosition = selectedArcherPosition - 1;
            selectArcher(army[selectedArcherPosition]);
        }
    }
    void GetArcherRight()
    {
        if (selectedArcherPosition == 5)
        {
            selectedArcherPosition = 0;
            selectArcher(army[0]);
        }
        else
        {
            selectedArcherPosition = selectedArcherPosition + 1;
            selectArcher(army[selectedArcherPosition]);
        }
    }


    //This section has all 6 hex movement functions
    void DownLeft(Vector3 currPosition)
    {
        selectedArcher.transform.position = currPosition + new Vector3(-(Mathf.Sqrt(3) / 2), 0, -1.5f);
        //Rigidbody rb = selectedArcher.GetComponent<Rigidbody>();
        // rb.AddForce(0, 0, 1,ForceMode.Impulse);
        //rb.GetComponent<Rigidbody>().MovePosition(currPosition + moveUp);
    }
    void DownRight(Vector3 currPosition)
    {
        selectedArcher.transform.position = currPosition + new Vector3((Mathf.Sqrt(3) / 2), 0, -1.5f);
    }
    void PushLeft(Vector3 currPosition)
    {
        selectedArcher.transform.position = currPosition + new Vector3(-Mathf.Sqrt(3) , 0, 0);
    }
    void PushRight(Vector3 currPosition)
    {
        selectedArcher.transform.position = currPosition + new Vector3(Mathf.Sqrt(3), 0, 0);
    }
    void UpLeft(Vector3 currPosition)
    {
        selectedArcher.transform.position = currPosition + new Vector3(-(Mathf.Sqrt(3) / 2), 0, 1.5f);
    }
    void UpRight(Vector3 currPosition)
    {
        selectedArcher.transform.position = currPosition + new Vector3((Mathf.Sqrt(3) / 2), 0, 1.5f);
    }
}
