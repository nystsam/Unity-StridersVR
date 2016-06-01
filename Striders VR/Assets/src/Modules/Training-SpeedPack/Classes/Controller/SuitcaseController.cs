﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StridersVR.Domain.SpeedPack;
using StridersVR.Modules.SpeedPack.Logic.Representatives;

public class SuitcaseController : MonoBehaviour {

	public ScriptableObject suitcasePartData;
	public ScriptableObject itemData;

	private GameObject currentPartAnimating;
	private GameObject verifier;

	private bool allowStartAnimation = false;
	private bool partSelected = false;
	private bool createParts = false;

	private int currentPartIndex;

	private Suitcase currentSuitcase;

	private Spot playerSpot;

	private RepresentativeSuitcase suitcaseLogic;

	private void instatiateVerifier(bool isCorrect)
	{
		GameObject _verifierPrefab = Resources.Load("Prefabs/Training-SpeedPack/Verifier", typeof(GameObject)) as GameObject;
		Vector3 _position = this.playerSpot.SpotPosition;

		_position.y = 0.3f;
		this.verifier = (GameObject)GameObject.Instantiate (_verifierPrefab, Vector3.zero, _verifierPrefab.transform.rotation);
		this.verifier.transform.parent = this.transform.GetChild(0).Find ("SuitcasePart").Find ("Items");
		this.verifier.transform.localPosition = _position;
		this.verifier.GetComponent<VerifierController> ().setAnimation (isCorrect);
	}

	private void animateParts()
	{
		if (!this.partSelected) 
		{
			this.currentPartAnimating = this.transform.GetChild(this.currentPartIndex).gameObject;
			this.partSelected = true;
			this.currentPartAnimating.GetComponent<SuitcasePartController>().allowAnimation();
		}

		if (this.currentPartAnimating != null && this.currentPartAnimating.GetComponent<SuitcasePartController>().IsAnimationDone) 
		{
			this.currentPartIndex --;
			this.partSelected = false;
			if(this.currentPartIndex < 1)
			{
				this.allowStartAnimation = false;
				this.createParts = true;
				this.currentSuitcase = null;
				if(this.playerSpot.IsAvailableSpot)
				{
					this.instatiateVerifier(true);
					// puntaje
				}
				else
				{
					this.instatiateVerifier(false);
					// puntaje
				}
			}
			this.currentPartAnimating.GetComponent<SuitcasePartController>().reflectItems(this.transform.GetChild(this.currentPartIndex).gameObject);
			GameObject.Destroy(this.transform.GetChild(this.currentPartIndex + 1).gameObject);
		}
	}

	private IEnumerator resetTableboard()
	{
		yield return new WaitForSeconds(1.5f);
		foreach(Transform child in this.transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		this.currentSuitcase = this.suitcaseLogic.getSuitcase ();
		this.suitcaseLogic.spawnItems (this.currentSuitcase);
		this.suitcaseLogic.spawnPlayerItem ();
	}
	
	public void placePlayerItem(Spot currentSpot)
	{
		GameObject _draggableItem = GameObject.FindGameObjectWithTag ("DraggableItem");

		_draggableItem.GetComponent<ItemDraggableController> ().stopDragging ();
		_draggableItem.GetComponent<BoxCollider> ().enabled = false;
		_draggableItem.transform.parent = this.transform.GetChild(0).Find ("SuitcasePart").Find ("Items");
		_draggableItem.transform.localPosition = currentSpot.SpotPosition;

		this.currentPartIndex = this.transform.childCount - 1;
		this.allowStartAnimation = true;
		this.playerSpot = currentSpot;		
	}


	#region Script
	void Awake () 
	{
		this.suitcaseLogic = new RepresentativeSuitcase (this.gameObject);
		this.suitcaseLogic.SetPartData = this.suitcasePartData;
		this.suitcaseLogic.SetItemData = this.itemData;
		this.currentSuitcase = this.suitcaseLogic.getSuitcase ();
	}

	void Start()
	{
		this.suitcaseLogic.spawnItems (this.currentSuitcase);
		this.suitcaseLogic.spawnPlayerItem ();
	}

	void Update()
	{
		if (this.allowStartAnimation) 
		{
			this.animateParts ();
		} 
		else if (this.createParts) 
		{
			this.createParts = false;
			StartCoroutine(this.resetTableboard());
		}
	}
	#endregion
}
