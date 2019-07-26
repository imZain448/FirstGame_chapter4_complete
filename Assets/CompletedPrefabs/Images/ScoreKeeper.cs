using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class ScoreKeeper : MonoBehaviour
{
    [UnityEngine.SerializeField]
    private int CurrentScore = 0;

    [UnityEngine.SerializeField]
    private int ScoreGainedPerHappyFace = 100;

    [UnityEngine.SerializeField]
    private int ScoreLostPerSadFace = 10;

    [UnityEngine.SerializeField]
    private int BallsGainedPerStarFace = 5;

    public int CurrentScoreProperty
    {
        get { return CurrentScore; }
    }

    public BallSpawning ballSpawner;

    public AudioClip starBUcketSound;
    public AudioClip HappyBucketSound;
    public AudioClip sadBUcketSound;

    public void BucketHit(bucket.BucketState bucketState)
    {
        if(bucketState == bucket.BucketState.Happy)
        {
            HappyBucketHit();
        }

        if(bucketState == bucket.BucketState.Sad)
        {
            SadBucketHit();
        }

        if(bucketState == bucket.BucketState.Star)
        {
            StarBucketHit();
        }
    }

    void HappyBucketHit()
    {
        CurrentScore += ScoreGainedPerHappyFace;

        GetComponent<AudioSource>().PlayOneShot(HappyBucketSound);
    }

    void SadBucketHit()
    {
        CurrentScore -= ScoreLostPerSadFace;

        GetComponent<AudioSource>().PlayOneShot(sadBUcketSound);
    }

    void StarBucketHit()
    {
        ballSpawner.ballCount += BallsGainedPerStarFace;

        GetComponent<AudioSource>().PlayOneShot(starBUcketSound);
    }
}
