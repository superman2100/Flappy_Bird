using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	private PlayerCont player;
	public GameObject startUI;
	public GameObject endUI;
	public Text result;
	public Text max;
	public Text score;

	void Start()
    {
		player = GameObject.FindWithTag("PLAYER").GetComponent<PlayerCont>();
		startUI.SetActive(true);
		endUI.SetActive(false);
	}

	
    void Update()
    {
        if(player.isDead == true)
		{
			endUI.SetActive(true);
			result.text = player.score.ToString();
			if (PlayerPrefs.GetInt("Max") < player.score)
			{
				PlayerPrefs.SetInt("Max", player.score);
			}
			max.text = PlayerPrefs.GetInt("Max").ToString();
		}
		if(player.isDead == false && GameManager.instance.isStart == true)
		{
			score.gameObject.SetActive(true);
			score.text = player.score.ToString();
		}
		else
		{
			score.gameObject.SetActive(false);
		}
    }

	public void StartButton()
	{
		GameManager.instance.isStart = true;
		startUI.SetActive(false);
		player.OnGameStart();
	}

	public void RestartButton()
	{
		GameManager.instance.isStart = false;
		SceneManager.LoadScene("InGame");
	}
}
