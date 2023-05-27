using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
	public bool isStart = false;

	void Awake()
	{
		if (instance != null)
			return;

		instance = this;

		Screen.SetResolution(1080, 1920, false);

		if(!PlayerPrefs.HasKey("Max"))
		{
			PlayerPrefs.SetInt("Max", 0);
		}
	}

	void Start()
    {
        
    }

    
    void Update()
    {
		StartGame();
    }

	private void StartGame() => Time.timeScale = isStart ? 1 : 0;
	
	
	
	
}
