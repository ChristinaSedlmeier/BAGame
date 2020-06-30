using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
	public bool easyDoor = true;

	
	public MenuManager menuManager;
	public void LevelStart()
	{

		menuManager.LoadGame();

	}
}
