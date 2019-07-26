using UnityEngine;
using System.Collections;

public class BucketController : MonoBehaviour
{

	public enum BucketState
	{
		Happy,
		Sad,
		Star
	}
	public BucketState currentBucketState;
	public Material happyFaceMat;
	public Material sadFaceMat;
	public Material starFaceMat;
	public Vector2 rerollRange;//The range we use when determining how long before we change modes

	public ScoreKeeperComplete scoreKeeperScript;

	void Start()
	{
		PickNewState();
	}

	void PickNewState()
	{
		ChangeState(GetRandomBucketState());

		float randomTime = Random.Range(rerollRange.x, rerollRange.y);

		Invoke("PickNewState", randomTime);
	}

	void ChangeState(BucketState newState)
	{
		currentBucketState = newState;

		gameObject.GetComponent<Renderer>().material = GetBucketMaterial();
	}

	BucketState GetRandomBucketState()
	{
		int randomNumber = Random.Range(0, 3);

		switch (randomNumber)
		{
			case 0:
				return BucketState.Happy;
			case 1:
				return BucketState.Sad;
			case 2:
				return BucketState.Star;
		}

		return BucketState.Happy;
	}

	Material GetBucketMaterial()
	{
		switch (currentBucketState)
		{
			case BucketState.Happy:
				return happyFaceMat;			
			case BucketState.Sad:
				return sadFaceMat;
			case BucketState.Star:
				return starFaceMat;
		}

		return happyFaceMat;
	}


	void OnTriggerEnter2D(Collider2D colliderHit)
	{
		if (colliderHit.CompareTag("Ball"))
		{
			scoreKeeperScript.BucketHit(currentBucketState);

			colliderHit.gameObject.tag = "";
		}
	}
}
