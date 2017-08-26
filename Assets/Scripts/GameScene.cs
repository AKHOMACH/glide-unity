using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour 
{

	private CanvasGroup fadeGroup;
	private float fadeInDuration = 1.75f;
	private bool gameStarted;

	private void Start()
	{
		// Grab then only CanvasGroup in the scene
		fadeGroup = FindObjectOfType<CanvasGroup>();

		// Start with a white screen, hide the logos
		fadeGroup.alpha = 1;
	}

	private void Update() 
	{
		if (Time.timeSinceLevelLoad <= fadeInDuration)
		{
			// Initial fade-in
			fadeGroup.alpha = 1 - (Time.timeSinceLevelLoad / fadeInDuration);
		}
		// If the initial fade-in is completed, and the game has not been started
		else if (!gameStarted)
		{
			// Ensure the fade is completly gone
			fadeGroup.alpha = 0;
			gameStarted = true;
		}
	}
	public void ExitScene()
	{
		SceneManager.LoadScene("Menu");
	}

	public void CompleteLevel()
	{
		// Complete the level, and save the progress
		SaveManager.Instance.CompleteLevel(Manager.Instance.currentLevel);
		
		// Focus level selection  when we return to Menu scene
		Manager.Instance.menuFocus = 1;

		ExitScene();
	}
}
