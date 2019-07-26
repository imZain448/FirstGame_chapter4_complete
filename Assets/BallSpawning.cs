using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSpawning : MonoBehaviour
{
    public GameObject BallPrefab;
    public int ballCount = 50;
    public Texture GameOverTextrure;
    public List<GameObject> BallList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        CheckMouseInput(); 
        // for test purposes

        CheckTouchInput(); 
        
    }

    void CheckMouseInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray ,  out hitInfo))
            {
                if(hitInfo.collider == gameObject.GetComponent<Collider>())
                {
                    SpawnBalls(hitInfo.point); 
                }
            }
        }
    }

    void CheckTouchInput()
    {
        if(Input.touchCount > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider == gameObject.GetComponent<Collider>())
                    {
                        SpawnBalls(hitInfo.point);
                    }
                }
            }
        }
    }

    void SpawnBalls(Vector3 spawnPosition)
    {
        if (ballCount > 0)
        {
            GameObject newBall = Instantiate(BallPrefab, spawnPosition, BallPrefab.transform.rotation) as GameObject;
            BallList.Add(newBall);
            ballCount--;
        }
    }

    private void OnGUI()
    {
        if (ballCount <= 0 && BallList.Count <= 0)
        {
            Rect NewRectangle = new Rect((Screen.width) / 2 - 100, (Screen.height) / 2 - 50, 400, 200);
            if (GUI.Button(NewRectangle, GameOverTextrure, new GUIStyle()))
            {
                SceneManager.LoadScene("GameLoadMenu");
            }
        }
    }

    public void KillBall(GameObject BallToKill)
    {
        if(BallList.Contains(BallToKill))
        {
            BallList.Remove(BallToKill);
            Destroy(BallToKill);
        }
    }
}
