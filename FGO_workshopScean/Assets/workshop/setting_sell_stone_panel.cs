using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting_sell_stone_panel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("sell_stone_panel").SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject obj;
	public void PanelHide (){
		obj.SetActive (false);
	}
}
