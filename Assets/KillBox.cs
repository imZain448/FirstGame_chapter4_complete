using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public BallSpawning BallSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallSpawner.KillBall(collision.gameObject);
    }
}
