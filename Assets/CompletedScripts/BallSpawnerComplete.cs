using UnityEngine;
using System.Collections;

public class BallSpawnerComplete : MonoBehaviour 
{
	public GameObject ballPrefab;
	public int ballCount = 50;

	void Update()
	{
		CheckMouseInput();

		CheckTouchInput();
	}

	void CheckMouseInput()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitTest;
			
			if(Physics.Raycast(ray,out hitTest))
			{
				if(hitTest.collider == gameObject.GetComponent<Collider>())
				{
					SpawnBall(hitTest.point);
				}
			}
		}
	}

	void CheckTouchInput()
	{
		if (Input.touchCount > 0) 
		{
			if(Input.touches[0].phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
				RaycastHit hitTest;
				
				if(Physics.Raycast(ray,out hitTest))
				{
					if(hitTest.collider == gameObject.GetComponent<Collider>())
					{
						SpawnBall(hitTest.point);
					}
				}
			}
		}
	}

	void SpawnBall(Vector3 spawnPosition)
	{
		if (ballCount > 0) 
		{
			Instantiate (ballPrefab, spawnPosition, ballPrefab.transform.rotation);
			ballCount--;
		}
	}

	void OnGUI()
	{
		if (ballCount <= 0) 
		{
			Rect popUpBoxRect = new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100);

			if(GUI.Button(popUpBoxRect, "Game Over! Press to Exit"))
			{
				Application.LoadLevel(0);
			}
		}
	}

}
