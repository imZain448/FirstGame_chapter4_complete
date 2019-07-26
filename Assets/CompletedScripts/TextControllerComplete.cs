using UnityEngine;
using System.Collections;

public class TextControllerComplete : MonoBehaviour 
{

	public BallSpawnerComplete ballSpawnerScript;
	public ScoreKeeperComplete scoreKeeperScript;

	public GUIText ballCountTextObject;
	public GUIText scoreTextObject;

	void Update()
	{
		scoreTextObject.text = "Score: " + scoreKeeperScript.currentScore.ToString();;
		ballCountTextObject.text = ballSpawnerScript.ballCount.ToString();
	}

}
