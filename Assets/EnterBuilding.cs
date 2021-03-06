﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBuilding : MonoBehaviour {

	private GameObject player;
	public AudioClip OakLabMusic;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}


	void Update()
	{
		

		if (player.GetComponent<Collider2D>().IsTouching(gameObject.GetComponent<Collider2D>()) && (player.GetComponent<SpriteRenderer>().sprite.name == "North_1" || player.GetComponent<SpriteRenderer>().sprite.name == "North_2")) {
		

			string currentScene = SceneManager.GetActiveScene ().name;
			PlayerPrefs.SetString ("LastScene", currentScene);
			PlayerPrefs.Save ();

			switch (gameObject.name) {

			case "OakLabDoor": 
				SceneManager.LoadScene ("OakLab");
				PlayMusic (OakLabMusic);
				break;

			case "PlayerHouseDoor":
				//DontDestroyOnLoad (player);
				SceneManager.LoadScene ("PlayerHouseBottom");
				break;

			case "GaryHouseDoor":
				//DontDestroyOnLoad (player);
				SceneManager.LoadScene ("GarysHouse");
				break;

			default:
				break;




			}
		}


	}

	void PlayMusic(AudioClip name)
	{
		GameObject.Find ("BgAudio").GetComponent<AudioSource> ().clip = name;
		GameObject.Find ("BgAudio").GetComponent<AudioSource> ().PlayDelayed (0.4f);
	}


}
