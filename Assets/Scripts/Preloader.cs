using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour 
{
	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minimumLogoTime = 3.0f; // Minimum time of that scene

	private void Start() 
	{
		// Grab then only CanvasGroup in the scene
		fadeGroup = FindObjectOfType<CanvasGroup>();

		// Start with a white screen, hide the logos
		fadeGroup.alpha = 1;

		// Pre load the game
		// $$ 

		// Get timestamp of the completion time
		// if load time is super, give it small  buffer time so we can apreciate the logo
		if (Time.time < minimumLogoTime)
			loadTime = minimumLogoTime;
		else 
			loadTime = Time.time;
	}

	private void Update () 
	{
		// Fade-In
		if (Time.time < minimumLogoTime)
		{
			fadeGroup.alpha = 1 - Time.time;
		}

		// Fade-Out
		if (Time.time > minimumLogoTime && loadTime != 0)
		{
			fadeGroup.alpha = Time.time - minimumLogoTime;
			if (fadeGroup.alpha >= 1)
			{
				SceneManager.LoadScene("Menu");
			}
			
		}

	}

}
