using UnityEngine;
using System.Collections;

public class ScoreKeeperComplete : MonoBehaviour 
{
	public int currentScore = 0;
	public int scorePerBall = 100;
	public int scoreLossPerSadBucket = 10;
	int ballsPerStar = 5;
	public BallSpawnerComplete ballSpawnerScript;
	public AudioClip starCollectSound;

	public void BucketHit(BucketController.BucketState bucketState)
	{
		switch (bucketState)
		{
			case BucketController.BucketState.Happy:
				HappyBucketHit();
				break;
			case BucketController.BucketState.Sad:
				SadBucketHit();
				break;
			case BucketController.BucketState.Star:
				StarBucketHit();
				break;
		}
	}

	void HappyBucketHit()
	{
		currentScore += scorePerBall;
	}

	void SadBucketHit()
	{
		currentScore -= scoreLossPerSadBucket;
	}

	void StarBucketHit()
	{
		ballSpawnerScript.ballCount += ballsPerStar;

		GetComponent<AudioSource>().PlayOneShot (starCollectSound);
	}
}
