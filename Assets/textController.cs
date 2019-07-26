using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{
    public ScoreKeeper ScoreKeeperScript;
    public BallSpawning BallSpawningScript;

    public Text Score;
    public Text BallsCount;


    // Update is called once per frame
    void Update()
    {
        BallsCount.text = BallSpawningScript.ballCount.ToString();

        Score.text = "Score " + ScoreKeeperScript.CurrentScoreProperty.ToString();
    }
}
