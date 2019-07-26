using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucket : MonoBehaviour
{

    public Vector2 reRandomRange;

    public BallSpawning BallSpawner;

    public enum BucketState
    {
        Happy,
        Sad,
        Star
    }

    public BucketState currentState;
    public Material HappyFaceMat;
    public Material SadFaceMat;
    public Material StarfaceMat;

    public ScoreKeeper ScorekeeperScript;

    // Start is called before the first frame update
    void Start()
    {
        PickState();
    }

    void PickState()
    {
        ChangeState(GetRandomBucketState());

        float RandomTime = Random.Range(reRandomRange.x, reRandomRange.y);

        Invoke("PickState", RandomTime);
    }

    void ChangeState(BucketState newState)
    {
        currentState = newState;

        SetBucketMaterail();
    }

    BucketState GetRandomBucketState()
    {

        int randomNumber = Random.Range(0, 3);

        if (randomNumber == 0)
            return BucketState.Happy;
        else if (randomNumber == 1)
            return BucketState.Sad;
        else
            return BucketState.Star;

    }

    void SetBucketMaterail()
    {
        gameObject.GetComponent<Renderer>().material = GetBucketMaterial();
    }

    Material GetBucketMaterial()
    {
        if (currentState == BucketState.Happy)
            return HappyFaceMat;
        else if (currentState == BucketState.Sad)
            return SadFaceMat;
        else
            return StarfaceMat;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            ScorekeeperScript.BucketHit(currentState);

            OnTriggerExit2D(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            BallSpawner.KillBall(collision.gameObject);
        }
    }

}
