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
    // Update is called once per frame
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
        if (Input.GetKeyDown("up"))
        {
            PushUp(selectedArcher.transform.position);
        }
        if (Input.GetKeyDown("left"))
        {
            PushLeft(selectedArcher.transform.position);
        }
        if (Input.GetKeyDown("right"))
        {
            PushRight(selectedArcher.transform.position);
        }
    }

    void selectArcher(GameObject thisArcher)
    {
        selectedArcher.transform.localScale = defaultSize;
        selectedArcher = thisArcher;
        thisArcher.transform.localScale = selectedSize;
    }

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

    void PushUp(Vector3 currPosition)
    {
        Rigidbody rb = selectedArcher.GetComponent<Rigidbody>();
       // rb.AddForce(0, 0, 1,ForceMode.Impulse);
        rb.GetComponent<Rigidbody>().MovePosition(currPosition + moveUp);
    }
    void PushLeft(Vector3 currPosition)
    {
        Rigidbody rb = selectedArcher.GetComponent<Rigidbody>();
        //rb.AddForce(-1, 0, 0, ForceMode.Impulse);
        rb.GetComponent<Rigidbody>().MovePosition(currPosition + moveLeft);
    }
    void PushRight(Vector3 currPosition)
    {
        Rigidbody rb = selectedArcher.GetComponent<Rigidbody>();
        //rb.AddForce(1, 0, 0, ForceMode.Impulse);
        rb.GetComponent<Rigidbody>().MovePosition(currPosition + moveRight);
    }
}
