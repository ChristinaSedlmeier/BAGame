using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
	public bool easyDoor = true;
	public Text levelText;
	public Text startText;


	public MenuManager menuManager;
	public void LevelStart()
	{

		menuManager.LoadGame();

	}

	private void Start()
	{
		
		levelText.text = "Level "+ FindObjectOfType<GameManager>().GetLevel().ToString() +" "+ FindObjectOfType<GameManager>().GetDifficulty();
		startText.text = "START";
	}
}