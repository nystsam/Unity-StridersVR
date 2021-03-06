﻿using UnityEngine;
using System.Collections;

public class HandFingerRayController : MonoBehaviour {

	[SerializeField] private float hitRange;

	private Vector3 direction;

	private RaycastHit hit;

	private GameObject button;

	private void setRayCast()
	{
		this.direction = this.transform.forward;
		Ray myRay = new Ray (transform.position, direction * hitRange);
		Debug.DrawRay (transform.position, direction * hitRange);
		if (Physics.Raycast (myRay, out hit, hitRange) && hit.collider.tag.Equals("GameButton")) 
		{
			if(this.button != null && this.button != hit.collider.gameObject)
			{
				this.button.GetComponent<SwitchButtonController>().DisableButton();
			}

			this.button = hit.collider.gameObject;
			this.button.GetComponent<SwitchButtonController>().EnableButton();
		}
		else if(this.button != null)
		{
			this.button.GetComponent<SwitchButtonController>().DisableButton();
			this.button = null;
		}

	}

	#region Script
	void Start () 
	{
		this.button = null;
	}

	void Update () 
	{
		this.setRayCast();
	}
	#endregion
}
