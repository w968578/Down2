using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudAccess : MonoBehaviour {

   static public UnityEngine.UI.Button NextButton { get; set; }
   static public UnityEngine.UI.Button AttackButton { get; set; }
    static public UnityEngine.UI.Button MoveButton { get; set; }
    static public UnityEngine.UI.Text UnitName;
    static public UnityEngine.UI.Text CurrentCoordinates; 
    static public UnityEngine.UI.Text LevelName; 

    //Format is what it should ideally be formatted to look like
    //Character limit is the limit of characters for the string
        //If you surpass this limit, text will go outside the box...

    // Use this for initialization
        //The "gameObject", is the panel in the hierarchy
    void Start () {
        //Ensures that all objects are retreived...
            //Incriments for every object retreived
        int ObjectInc = 0;
        UnityEngine.UI.Button[] Buttons;
        UnityEngine.UI.Text[] Texts;

        Buttons = gameObject.GetComponentsInChildren<UnityEngine.UI.Button>(false);
        Texts = gameObject.GetComponentsInChildren<UnityEngine.UI.Text>(false);
        
        for(int x = 0; x < Buttons.Length; x++)
        {
            if(Buttons[x].name == "NextButton")
            {
                NextButton = Buttons[x]; 
                ObjectInc++; 
            }
            else if(Buttons[x].name == "MoveButton")
            {
                MoveButton = Buttons[x]; 
                ObjectInc++; 
            }
            else if(Buttons[x].name == "AttackButton")
            {
                AttackButton = Buttons[x];
                ObjectInc++; 
            }
        }


        for(int x = 0; x < Texts.Length; x++)
        {
            if (Texts[x].name == "CoordinatesText")
            {
                CurrentCoordinates = Texts[x]; 
                ObjectInc++;
            }
            else if (Texts[x].name == "PlayerNameText")
            {
               UnitName =  Texts[x];
                ObjectInc++;
            }
            else if (Texts[x].name == "LevelNameText")
            {
                LevelName = Texts[x];
                ObjectInc++;
            }
        }

        if (ObjectInc != 6)
        {
            throw new System.InvalidOperationException("Only " + ObjectInc + 
                " HUD objects found. " + (6 - ObjectInc) + " HUD objects not found.");
        }

        updateUnitName("BobTheArcher");
        updateCoordinate("0, 1");
        updateLevelName("Sea Level"); 


    }
	
    static public void updateUnitName(string Name)
    {
        UnitName.text = Name; 
    }

    //Format
        //X,Y
    static public void updateCoordinate(string Coord)
    {
        CurrentCoordinates.text = Coord;
    }

    static public void updateLevelName(string newLevelName)
    {
        LevelName.text = newLevelName; 
    }

    

	// Update is called once per frame
	void Update () {
		
	}

    
}

