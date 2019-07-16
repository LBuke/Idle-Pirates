using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using TMPro;

public class TeddehSteamManager : MonoBehaviour
{

	public TMP_Text textLabel;

	// Use this for initialization
	void Start () {
		
		if (!SteamManager.Initialized)
			return;

		textLabel.text = SteamFriends.GetPersonaName();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
