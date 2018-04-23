using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SampleScript : MonoBehaviour {

    void Start()
    {
         
    }
	
    public void YEE()
    {
        UnityEngine.UI.Button B;

        B = hudAccess.AttackButton;

        B.image.CrossFadeAlpha(0.0f, 1.0f, false);
    }
}
