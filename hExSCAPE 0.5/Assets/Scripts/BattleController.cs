//Script file for BattleController class
//Gabriel Mayo
//4-20-2018
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BattleController : MonoBehaviour 
{
	//enum type for simple state checks
	public enum States
	{	
		BaseBattleState,
		TargetSelectState,
		AttackTargetState
	}
	
	
	private GameObject currentUnit;
	private GameObject targetUnit;
	private States currentState = States.BaseBattleState;	//track the current state
	UnityEvent clickTarget;
	
	void Start() 
	{
		currentUnit = //get reference to current unit
		if (clickTarget == null)
		{
			clickTarget = new UnityEvent();
		}
	}
	
	void Update()
	{
		
	}
	
	public void Attack()
	{
		if (currentState != States.BaseBattleState)
		{
			currentState = States.BaseBattleState;
		}
		SelectTarget();
		CalculateDamage();
	}

	private void SelectTarget()
	{
		currentState = TargetSelectState;
		clickTarget.AddListener(TargetAcquired);
		if(Input.GetMouseButtonDown(0) && clickTarget != null)
		{
			clickTarget.Invoke();
		}
		currentState = BaseBattleState;
		clickTarget.RemoveListener(TargetAcquired);
	}
	
	private void TargetAcquired()
	{
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (currentState == States.TargetSelectState)
		{
			if (Physics.Raycast(mouseRay out hitInfo))
			{
				targetUnit = hitObject;
			}
			
		}
	}
	
	//Doesn't calculate damage, just kills the target
	private void CalculateDamage()
	{
		currentState = States.AttackTargetState;
		Destroy(targetUnit);
		currentState = States.BaseBattleState;
	}
}